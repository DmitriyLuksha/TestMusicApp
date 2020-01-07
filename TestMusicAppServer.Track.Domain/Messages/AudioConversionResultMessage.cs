namespace TestMusicAppServer.Track.Domain.Messages
{
    public class AudioConversionResultMessage
    {
        public bool IsSuccess { get; set; }

        public string FileName { get; set; }

        public AudioConversionAdditionalData AdditionalData { get; set; }

    }
}
