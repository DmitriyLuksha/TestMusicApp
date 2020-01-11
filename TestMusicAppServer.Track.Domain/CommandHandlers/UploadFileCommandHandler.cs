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
using TestMusicAppServer.Track.Domain.Storages;

namespace TestMusicAppServer.Track.Domain.CommandHandlers
{
    public class UploadFileCommandHandler : BaseCommandHandler<UploadFileCommand>
    {
        private readonly IMediator _mediator;
        private readonly IAudioUploadingMessageBroker _audioUploadingMessageBroker;
        private readonly IAudioStorage _audioStorage;

        public UploadFileCommandHandler(
            IMediator mediator,
            IAudioUploadingMessageBroker audioUploadingMessageBroker,
            IAudioStorage audioStorage
        )
        {
            this._mediator = mediator;
            this._audioUploadingMessageBroker = audioUploadingMessageBroker;
            this._audioStorage = audioStorage;
        }

        protected override async Task Handle(UploadFileCommand command, CancellationToken cancellationToken)
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
            
            var fileName = $"{command.UserId}__{Guid.NewGuid()}";
            await _audioStorage.UploadUnprocessedAudioFileAsync(fileName, command.File);

            var audioConversionMessage = new AudioConversionMessage
            {
                FileName = fileName,
                AdditionalData = new AudioConversionAdditionalData
                {
                    UserId = command.UserId,
                    PlaylistId = command.PlaylistId,
                    TrackName = command.Name
                }
            };

            try
            {
                await _audioUploadingMessageBroker.SendAudioConversionRequest(audioConversionMessage);
            }
            catch
            {
                // TODO Logging

                await _audioStorage.DeleteUnprocessedAudioFileAsync(fileName);

                throw;
            }
        }
    }
}
