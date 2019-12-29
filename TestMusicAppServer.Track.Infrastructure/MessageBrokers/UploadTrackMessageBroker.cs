using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Options;
using TestMusicAppServer.Common.Configurations;
using TestMusicAppServer.Track.Domain.MessageBrokers;

namespace TestMusicAppServer.Track.Infrastructure.MessageBrokers
{
    public class UploadTrackMessageBroker : IUploadTrackMessageBroker
    {
        private readonly ConnectionStringsConfig _connectionStringsConfig;
        private readonly ServiceBusConfig _serviceBusConfig;

        public UploadTrackMessageBroker(
            IOptions<ConnectionStringsConfig> connectionStringsConfig,
            IOptions<ServiceBusConfig> serviceBusConfig
        )
        {
            this._connectionStringsConfig = connectionStringsConfig.Value;
            this._serviceBusConfig = serviceBusConfig.Value;
        }

        public async Task SendFileConversionRequest()
        {
            var connectionString = _connectionStringsConfig.TestMusicAppServiceBus;
            var queueName = _serviceBusConfig.AudioConversionQueueName;

            var queueClient = new QueueClient(connectionString, queueName);

            var messageBody = "hi";
            var message = new Message(Encoding.UTF8.GetBytes(messageBody));

            await queueClient.SendAsync(message);

            await queueClient.CloseAsync();
        }
    }
}
