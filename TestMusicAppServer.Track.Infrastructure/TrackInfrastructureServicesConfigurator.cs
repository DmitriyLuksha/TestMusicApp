using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestMusicAppServer.Common.ConfigurationKeys;
using TestMusicAppServer.Shared.Domain.Contracts;
using TestMusicAppServer.Track.Domain.MessageBrokers;
using TestMusicAppServer.Track.Domain.Storages;
using TestMusicAppServer.Track.Infrastructure.Contexts;
using TestMusicAppServer.Track.Infrastructure.Listeners;
using TestMusicAppServer.Track.Infrastructure.MessageBrokers;
using TestMusicAppServer.Track.Infrastructure.Repositories;
using TestMusicAppServer.Track.Infrastructure.Storages;

namespace TestMusicAppServer.Track.Infrastructure
{
    public static class TrackInfrastructureServicesConfigurator
    {
        public static void ConfigureTrackInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(ConnectionStringKeys.TestMusicAppDb);
            services.AddDbContext<TrackContext>(options => options.UseSqlServer(connectionString));

            services.AddSingleton(typeof(IAudioConversionResultListener),
                typeof(AudioConversionResultListener));

            services.AddScoped(typeof(IAudioUploadingMessageBroker),
                typeof(AudioUploadingMessageBroker));

            services.AddScoped(typeof(IRepository<Domain.Entities.Track>),
                typeof(TrackRepository));

            services.AddScoped(typeof(IAudioStorage), typeof(AudioStorage));
        }
    }
}
