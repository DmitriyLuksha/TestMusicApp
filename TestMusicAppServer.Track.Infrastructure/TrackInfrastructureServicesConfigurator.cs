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

            services.AddSingleton<IAudioUploadingResultListener, AudioUploadingResultListener>();

            services.AddScoped<IAudioUploadingMessageBroker, AudioUploadingMessageBroker>();

            services.AddScoped<IRepository<Domain.Entities.Track>, TrackRepository>();

            services.AddScoped<IAudioStorage, AudioStorage>();
        }
    }
}
