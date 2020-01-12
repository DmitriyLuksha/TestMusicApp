namespace TestMusicAppServer.Track.Domain.Messages
{
    public class AudioUploadingResultMessage
    {
        public bool IsSuccess { get; set; }

        public string FileName { get; set; }

        public AudioUploadingAdditionalData AdditionalData { get; set; }

    }
}
