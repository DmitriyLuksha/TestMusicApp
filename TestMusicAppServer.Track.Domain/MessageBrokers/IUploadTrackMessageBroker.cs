using System.Threading.Tasks;
using TestMusicAppServer.Shared.Domain.Contracts;

namespace TestMusicAppServer.Track.Domain.MessageBrokers
{
    public interface IUploadTrackMessageBroker : IMessageBroker
    {
        Task SendFileConversionRequest();
    }
}
