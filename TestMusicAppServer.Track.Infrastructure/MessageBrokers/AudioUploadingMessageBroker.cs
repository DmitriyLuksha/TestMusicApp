using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestMusicAppServer.Common.Configurations;
using TestMusicAppServer.Shared.Infrastructure.ServiceBusMessageGenerators;
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
            var connectionString = _connectionStringsConfig.TestMusicAppServiceBus;
            var queueName = _serviceBusConfig.AudioConversionQueueName;
            
            var messageJson = JsonConvert.SerializeObject(audioConversionMessage);
            var queueClient = new QueueClient(connectionString, queueName);
            var message = ServiceBusMessageGenerator.GenerateMessage(messageJson);

            await queueClient.SendAsync(message);

            await queueClient.CloseAsync();
        }
    }
}
