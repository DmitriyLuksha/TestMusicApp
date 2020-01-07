using System;
using TestMusicAppServer.Shared.Domain.Commands;

namespace TestMusicAppServer.Track.Domain.Commands
{
    public class AddTrackCommand : ICommand
    {
        public Guid TrackId { get; set; }

        public string FileName { get; set; }

        public Guid PlaylistId { get; set; }

        public string TrackName { get; set; }
    }
}
