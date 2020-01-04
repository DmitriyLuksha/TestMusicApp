namespace TestMusicAppServer.Common.Configurations
{
    public class ServiceBusConfig
    {
        public string AudioConversionQueueName { get; set; }

        public string AudioUploadingResultQueueName { get; set; }
    }
}
