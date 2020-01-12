namespace TestMusicAppServer.Track.Domain.Messages
{
    public class YoutubeConversionMessage
    {
        public string VideoId { get; set; }

        public AudioUploadingAdditionalData AdditionalData { get; set; }
    }
}
