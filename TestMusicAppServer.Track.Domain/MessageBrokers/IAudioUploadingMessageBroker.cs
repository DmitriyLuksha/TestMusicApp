using System;
using System.Threading.Tasks;
using TestMusicAppServer.Track.Domain.Messages;

namespace TestMusicAppServer.Track.Domain.MessageBrokers
{
    public interface IAudioUploadingMessageBroker
    {
        Task SendAudioConversionRequest(AudioConversionMessage audioConversionMessage);

        Task SendYoutubeConversionRequest(YoutubeConversionMessage youtubeConversionMessage);
    }
}
