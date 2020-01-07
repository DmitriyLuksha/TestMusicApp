using System;
using TestMusicAppServer.Shared.Domain.Events;

namespace TestMusicAppServer.Track.Domain.Events
{
    public class TrackUploadFinishedEvent : IEvent
    {
        public bool IsSuccess { get; set; }

        public string FileName { get; set; }

        public Guid PlaylistId { get; set; }

        public string TrackName { get; set; }
    }
}
