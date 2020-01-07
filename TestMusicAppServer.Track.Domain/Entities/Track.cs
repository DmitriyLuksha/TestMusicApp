using System;
using TestMusicAppServer.Shared.Domain.Entities;

namespace TestMusicAppServer.Track.Domain.Entities
{
    public class Track : BaseEntity
    {
        private Track() { }

        public Track(Guid id, Guid playlistId, string trackName, string fileName)
        {
            this.Id = id;
            this.PlaylistId = playlistId;
            this.TrackName = trackName;
            this.FileName = fileName;
        }

        public Guid PlaylistId { get; private set; }

        public string TrackName { get; private set; }

        public string FileName { get; private set; }
    }
}
