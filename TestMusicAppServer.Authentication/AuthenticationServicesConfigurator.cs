using Microsoft.Extensions.DependencyInjection;
using TestMusicAppServer.Authentication.Services;

namespace TestMusicAppServer.Authentication
{
    public static class AuthenticationServicesConfigurator
    {
        public static void ConfigureAuthenticationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAccountService), typeof(AccountService));
        }
    }
}
