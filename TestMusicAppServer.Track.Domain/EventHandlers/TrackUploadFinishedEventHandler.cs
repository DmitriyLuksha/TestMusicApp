using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TestMusicAppServer.Shared.Domain.EventHandlers;
using TestMusicAppServer.Track.Domain.Commands;
using TestMusicAppServer.Track.Domain.Events;

namespace TestMusicAppServer.Track.Domain.EventHandlers
{
    public class TrackUploadFinishedEventHandler : BaseEventHandler<TrackUploadFinishedEvent>
    {
        private readonly IMediator _mediator;

        public TrackUploadFinishedEventHandler(IMediator mediator)
        {
            this._mediator = mediator;
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
                
                await _mediator.Send(command);
            }
            else
            {
                // TODO Logging and user notification
            }
        }
    }
}
