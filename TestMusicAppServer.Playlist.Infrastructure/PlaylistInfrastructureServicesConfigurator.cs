using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestMusicAppServer.Common.ConfigurationKeys;
using TestMusicAppServer.Playlist.Infrastructure.Contexts;
using TestMusicAppServer.Playlist.Infrastructure.Repositories;
using TestMusicAppServer.Shared.Domain.Contracts;

namespace TestMusicAppServer.Playlist.Infrastructure
{
    public static class PlaylistInfrastructureServicesConfigurator
    {
        public static void ConfigurePlaylistInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString(ConnectionStringKeys.TestMusicAppDb);
            services.AddDbContext<PlaylistContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IRepository<Domain.Entities.Playlist>, PlaylistRepository>();
        }
    }
}
