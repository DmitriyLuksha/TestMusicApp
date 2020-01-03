using Microsoft.Extensions.DependencyInjection;
using TestMusicAppServer.Track.Domain.MessageBrokers;
using TestMusicAppServer.Track.Domain.Storages;
using TestMusicAppServer.Track.Infrastructure.MessageBrokers;
using TestMusicAppServer.Track.Infrastructure.Storages;

namespace TestMusicAppServer.Track.Infrastructure
{
    public static class TrackInfrastructureServicesConfigurator
    {
        public static void ConfigureTrackInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAudioUploadingMessageBroker),
                typeof(AudioUploadingMessageBroker));

            services.AddScoped(typeof(IAudioStorage), typeof(AudioStorage));
        }
    }
}
