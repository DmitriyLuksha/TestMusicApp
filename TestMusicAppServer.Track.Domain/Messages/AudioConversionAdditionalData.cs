using System;

namespace TestMusicAppServer.Track.Domain.Messages
{
    public class AudioConversionAdditionalData
    {
        public Guid PlaylistId { get; set; }

        public string TrackName { get; set; }
    }
}
