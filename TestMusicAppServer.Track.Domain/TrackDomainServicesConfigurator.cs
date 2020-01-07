using Microsoft.Extensions.DependencyInjection;
using TestMusicAppServer.Track.Domain.Mappers;

namespace TestMusicAppServer.Track.Domain
{
    public static class TrackDomainServicesConfigurator
    {
        public static void ConfigureTrackDomainServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(ITrackMapper), typeof(TrackMapper));
        }
    }
}
