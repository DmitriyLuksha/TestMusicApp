using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TestMusicAppServer.ClientNotifications.NotificationMessages;
using TestMusicAppServer.ClientNotifications.Services;
using TestMusicAppServer.Shared.Domain.EventHandlers;
using TestMusicAppServer.Track.Domain.Commands;
using TestMusicAppServer.Track.Domain.Events;

namespace TestMusicAppServer.Track.Domain.EventHandlers
{
    public class TrackUploadFinishedEventHandler : BaseEventHandler<TrackUploadFinishedEvent>
    {
        private readonly IMediator _mediator;
        private readonly IClientNotificationService _clientNotificationService;

        public TrackUploadFinishedEventHandler(
            IMediator mediator,
            IClientNotificationService clientNotificationService)
        {
            this._mediator = mediator;
            this._clientNotificationService = clientNotificationService;
        }

        public override async Task Handle(TrackUploadFinishedEvent @event, CancellationToken cancellationToken)
        {
            if (@event.IsSuccess)
            {
                var command = new AddTrackCommand
                {
                    TrackId = Guid.NewGuid(),
                    FileName = @event.FileName,
                    PlaylistId = @event.PlaylistId,
                    TrackName = @event.TrackName
                };
                
                await _mediator.Send(command, cancellationToken);
            }
            else
            {
                // TODO Logging
            }

            var notificationMessage = new TrackUploadFinishedNotificationMessage
            {
                IsSuccess = @event.IsSuccess,
                PlaylistId = @event.PlaylistId,
                TrackName = @event.TrackName
            };

            await _clientNotificationService.SendNotificationMessageAsync(@event.UserId, notificationMessage);
        }
    }
}
