using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TestMusicAppServer.Playlist.Definitions.ValidationRequests;
using TestMusicAppServer.Shared.Domain.CommandHandlers;
using TestMusicAppServer.Track.Domain.Commands;
using TestMusicAppServer.Track.Domain.MessageBrokers;

namespace TestMusicAppServer.Track.Domain.CommandHandlers
{
    public class UploadFileCommandHandler : BaseCommandHandler<UploadFileCommand>
    {
        private readonly IMediator _mediator;
        private readonly IUploadTrackMessageBroker _uploadTrackMessageBroker;

        public UploadFileCommandHandler(
            IMediator mediator,
            IUploadTrackMessageBroker uploadTrackMessageBroker
        )
        {
            this._mediator = mediator;
            this._uploadTrackMessageBroker = uploadTrackMessageBroker;
        }

        protected override async Task Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {
            var validationRequest = new PlaylistAccessibilityValidationRequest()
            {
                PlaylistId = request.PlaylistId,
                UserId = request.UserId
            };

            var result = await _mediator.Send(validationRequest, cancellationToken);

            if (!result.IsValid)
            {
                throw new ValidationException(result.InvalidityReason);
            }

            try
            {
                await _uploadTrackMessageBroker.SendFileConversionRequest();
            }
            catch
            {
                // TODO Logging
                // TODO Remove uploaded file
                throw;
            }
        }
    }
}
