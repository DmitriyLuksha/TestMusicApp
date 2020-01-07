using System.Text;
using Microsoft.Azure.ServiceBus;

namespace TestMusicAppServer.Shared.Infrastructure.ServiceBusMessageConverters
{
    public static class ServiceBusMessageConverter
    {
        public static Message StringToMessage(string content)
        {
            return new Message(Encoding.UTF8.GetBytes(content));
        }

        public static string MessageToString(Message message)
        {
            return Encoding.UTF8.GetString(message.Body);
        }
    }
}
