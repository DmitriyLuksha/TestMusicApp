using System;
using System.Threading.Tasks;

namespace TestMusicAppServer.Track.Domain.MessageBrokers
{
    public interface IAudioUploadingMessageBroker
    {
        Task SendFileConversionRequest(string fileName, Guid playlistId, string trackName);
    }
}
