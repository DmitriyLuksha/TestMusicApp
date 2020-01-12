using System;

namespace TestMusicAppServer.Track.Domain.Messages
{
    public class AudioUploadingAdditionalData
    {
        public Guid UserId { get; set; }

        public Guid PlaylistId { get; set; }

        public string TrackName { get; set; }
    }
}
