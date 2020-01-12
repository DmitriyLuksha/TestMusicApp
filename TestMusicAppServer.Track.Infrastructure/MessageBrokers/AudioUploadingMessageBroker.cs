using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Threading.Tasks;
using TestMusicAppServer.Common.Configurations;
using TestMusicAppServer.Shared.Infrastructure.ServiceBusMessageConverters;
using TestMusicAppServer.Track.Domain.MessageBrokers;
using TestMusicAppServer.Track.Domain.Messages;

namespace TestMusicAppServer.Track.Infrastructure.MessageBrokers
{
    public class AudioUploadingMessageBroker : IAudioUploadingMessageBroker
    {
        private readonly ConnectionStringsConfig _connectionStringsConfig;
        private readonly ServiceBusConfig _serviceBusConfig;
        
        public AudioUploadingMessageBroker(
            IOptions<ConnectionStringsConfig> connectionStringsConfig,
            IOptions<ServiceBusConfig> serviceBusConfig
        )
        {
            this._connectionStringsConfig = connectionStringsConfig.Value;
            this._serviceBusConfig = serviceBusConfig.Value;
        }

        public async Task SendAudioConversionRequest(AudioConversionMessage audioConversionMessage)
        {
            await SendMessage(_serviceBusConfig.AudioConversionQueueName, audioConversionMessage);
        }

        public async Task SendYoutubeConversionRequest(YoutubeConversionMessage youtubeConversionMessage)
        {
            await SendMessage(_serviceBusConfig.YoutubeConversionQueueName, youtubeConversionMessage);
        }

        // TODO Move to helper class
        private async Task SendMessage(string queueName, object value)
        {
            var connectionString = _connectionStringsConfig.TestMusicAppServiceBus;
            
            var messageJson = JsonConvert.SerializeObject(value);
            var queueClient = new QueueClient(connectionString, queueName);
            var message = ServiceBusMessageConverter.StringToMessage(messageJson);

            await queueClient.SendAsync(message);
            await queueClient.CloseAsync();
        }
    }
}
