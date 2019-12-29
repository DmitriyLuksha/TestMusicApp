using Microsoft.Extensions.DependencyInjection;
using TestMusicAppServer.Track.Domain.MessageBrokers;
using TestMusicAppServer.Track.Infrastructure.MessageBrokers;

namespace TestMusicAppServer.Track.Infrastructure
{
    public static class TrackInfrastructureServicesConfigurator
    {
        public static void ConfigureTrackInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IUploadTrackMessageBroker),
                typeof(UploadTrackMessageBroker));
        }
    }
}
