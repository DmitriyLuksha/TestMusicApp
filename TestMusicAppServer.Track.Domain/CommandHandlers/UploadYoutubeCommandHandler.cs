using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TestMusicAppServer.Playlist.Definitions.ValidationRequests;
using TestMusicAppServer.Shared.Domain.CommandHandlers;
using TestMusicAppServer.Track.Domain.Commands;
using TestMusicAppServer.Track.Domain.MessageBrokers;
using TestMusicAppServer.Track.Domain.Messages;

namespace TestMusicAppServer.Track.Domain.CommandHandlers
{
    public class UploadYoutubeCommandHandler: BaseCommandHandler<UploadYoutubeCommand>
    {
        private readonly IMediator _mediator;
        private readonly IAudioUploadingMessageBroker _audioUploadingMessageBroker;

        public UploadYoutubeCommandHandler(
            IMediator mediator,
            IAudioUploadingMessageBroker audioUploadingMessageBroker
        )
        {
            this._mediator = mediator;
            this._audioUploadingMessageBroker = audioUploadingMessageBroker;
        }

        protected override async Task Handle(UploadYoutubeCommand command, CancellationToken cancellationToken)
        {
            var validationRequest = new PlaylistAccessibilityValidationRequest()
            {
                PlaylistId = command.PlaylistId,
                UserId = command.UserId
            };

            var result = await _mediator.Send(validationRequest, cancellationToken);

            if (!result.IsValid)
            {
                throw new ValidationException(result.InvalidityReason);
            }
            
            var youtubeConversionMessage = new YoutubeConversionMessage
            {
                VideoId = command.VideoId,
                AdditionalData = new AudioUploadingAdditionalData
                {
                    UserId = command.UserId,
                    PlaylistId = command.PlaylistId,
                    TrackName = command.Name
                }
            };
            
            await _audioUploadingMessageBroker.SendYoutubeConversionRequest(youtubeConversionMessage);
        }
    }
}
