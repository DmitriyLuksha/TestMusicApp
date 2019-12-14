using Microsoft.AspNetCore.Builder;
using TestMusicAppServer.Api.Middleware;

namespace TestMusicAppServer.Api.Extensions
{
    public static class RegisterMiddleware
    {
        public static void UseExceptionHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware(typeof(ExceptionHandlingMiddleware));
        }
    }
}
