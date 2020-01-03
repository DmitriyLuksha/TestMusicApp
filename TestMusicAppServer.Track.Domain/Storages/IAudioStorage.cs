using System.IO;
using System.Threading.Tasks;

namespace TestMusicAppServer.Track.Domain.Storages
{
    public interface IAudioStorage
    {
        Task UploadUnprocessedAudioFileAsync(string fileName, Stream content);

        Task DeleteUnprocessedAudioFileAsync(string fileName);
    }
}
