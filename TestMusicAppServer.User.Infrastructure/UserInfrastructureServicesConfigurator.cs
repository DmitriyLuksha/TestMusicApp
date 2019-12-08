using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestMusicAppServer.Shared.Domain.Contracts;
using TestMusicAppServer.User.Infrastructure.Contexts;
using TestMusicAppServer.User.Infrastructure.Repositories;

namespace TestMusicAppServer.User.Infrastructure
{
    public static class UserInfrastructureServicesConfigurator
    {
        public static void ConfigureUserInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("TestMusicAppDb");
            services.AddDbContext<UserContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped(typeof(IRepository<Domain.Entities.User>),
                typeof(UserRepository));
        }
    }
}
