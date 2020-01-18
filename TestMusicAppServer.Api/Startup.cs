using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using TestMusicAppServer.Api.CloseableListenersHandlers;
using TestMusicAppServer.Api.DependencyResolvers;
using TestMusicAppServer.Api.Extensions;
using TestMusicAppServer.Api.Handlers;
using TestMusicAppServer.Authentication;
using TestMusicAppServer.ClientNotifications;
using TestMusicAppServer.ClientNotifications.Hubs;
using TestMusicAppServer.Common.Configurations;
using TestMusicAppServer.Playlist.Domain;
using TestMusicAppServer.Playlist.Infrastructure;
using TestMusicAppServer.Track.Domain;
using TestMusicAppServer.Track.Infrastructure;
using TestMusicAppServer.User.Infrastructure;

namespace TestMusicAppServer.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                // TODO: Add prefixes
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.Configure<ConnectionStringsConfig>(Configuration.GetSection("ConnectionStrings"));
            services.Configure<ServiceBusConfig>(Configuration.GetSection("ServiceBus"));
            services.Configure<StorageConfig>(Configuration.GetSection("Storage"));

            // TODO Implement autoresolving dependencies for the base classes and interfaces like IService
            services.ConfigureAuthenticationServices();
            services.ConfigureUserInfrastructureServices(Configuration);
            services.ConfigurePlaylistInfrastructureServices(Configuration);
            services.ConfigurePlaylistDomainServices(Configuration);
            services.ConfigureTrackInfrastructureServices(Configuration);
            services.ConfigureTrackDomainServices();
            services.ConfigureClientNotificationsServices();

            services.AddMediatRForSolution("TestMusicAppServer.");

            services.AddApplicationInsightsTelemetry();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Events = new CookieAuthenticationEvents
                    {
                        OnRedirectToLogin = UserNotAuthenticatedHandler.Handle
                    };

                    options.Cookie.SameSite = SameSiteMode.None;
                });

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });

            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            }));

            var signalRConnectionString = Configuration.GetConnectionString("TestMusicAppSignalR");

            services.AddSignalR()
                .AddAzureSignalR(signalRConnectionString);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = InvalidModelStateHandler.FormatResponse;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            IApplicationLifetime applicationLifetime
        )
        {
            applicationLifetime.ApplicationStarted.Register(OnApplicationStarted);
            applicationLifetime.ApplicationStopping.Register(OnApplicationStopping);

            CloseableListenersHandler.ResolveListeners(app.ApplicationServices);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseExceptionHandlingMiddleware();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}");
            });
            
            app.UseAzureSignalR(routes =>
            {
                routes.MapHub<NotificationHub>("/notifications");
            });
        }
        
        private void OnApplicationStarted()
        {
            CloseableListenersHandler.RegisterListeners();
        }

        private void OnApplicationStopping()
        {
            CloseableListenersHandler.CloseListeners();
        }
    }
}
