using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Options;
using TestMusicAppServer.Common.Configurations;

namespace TestMusicAppServer.Track.Infrastructure.Listeners
{
    public class AudioConversionResultListener : IAudioConversionResultListener
    {
        private readonly ServiceBusConfig _serviceBusConfig;
        private readonly ConnectionStringsConfig _connectionStringsConfig;
        
        private IQueueClient _queueClient;

        public AudioConversionResultListener(
            IOptions<ConnectionStringsConfig> connectionStringsConfig,
            IOptions<ServiceBusConfig> serviceBusConfig
        )
        {
            this._connectionStringsConfig = connectionStringsConfig.Value;
            this._serviceBusConfig = serviceBusConfig.Value;
        }

        public void RegisterListener()
        {
            var serviceBusConnectionString = _connectionStringsConfig.TestMusicAppServiceBus;
            var queueName = _serviceBusConfig.AudioConversionQueueName;

            _queueClient = new QueueClient(serviceBusConnectionString, queueName);

            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            _queueClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
        }

        public void CloseListener()
        {
            _queueClient
                ?.CloseAsync()
                .GetAwaiter()
                .GetResult();
        }

        private async Task ProcessMessagesAsync(Message message, CancellationToken cancellationToken)
        {
            throw new Exception();
        }

        private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs args)
        {
            // TODO
            return Task.CompletedTask;
        }
    }
}
