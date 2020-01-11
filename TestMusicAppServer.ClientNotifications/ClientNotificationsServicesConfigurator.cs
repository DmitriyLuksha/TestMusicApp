using Microsoft.Extensions.DependencyInjection;
using TestMusicAppServer.ClientNotifications.Services;

namespace TestMusicAppServer.ClientNotifications
{
    public static class ClientNotificationsServicesConfigurator
    {
        public static void ConfigureClientNotificationsServices(this IServiceCollection services)
        {
            services.AddScoped<IClientNotificationService, ClientNotificationService>();
        }
    }
}
