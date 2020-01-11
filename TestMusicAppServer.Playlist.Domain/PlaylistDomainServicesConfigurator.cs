using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestMusicAppServer.Playlist.Domain.Mappers;

namespace TestMusicAppServer.Playlist.Domain
{
    public static class PlaylistDomainServicesConfigurator
    {
        public static void ConfigurePlaylistDomainServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPlaylistMapper, PlaylistMapper>();
        }
    }
}
