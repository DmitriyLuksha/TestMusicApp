using System.Text;
using Microsoft.Azure.ServiceBus;

namespace TestMusicAppServer.Shared.Infrastructure.ServiceBusMessageGenerators
{
    public static class ServiceBusMessageGenerator
    {
        public static Message GenerateMessage(string content)
        {
            return new Message(Encoding.UTF8.GetBytes(content));
        }
    }
}
