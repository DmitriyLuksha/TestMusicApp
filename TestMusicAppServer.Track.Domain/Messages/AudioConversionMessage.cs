using System;

namespace TestMusicAppServer.Track.Domain.Messages
{
    public class AudioConversionMessageAdditionalData
    {
        public Guid PlaylistId { get; set; }

        public string TrackName { get; set; }
    }

    public class AudioConversionMessage
    {
        public string FileName { get; set; }

        public AudioConversionMessageAdditionalData AdditionalData { get; set; }
    }
}
