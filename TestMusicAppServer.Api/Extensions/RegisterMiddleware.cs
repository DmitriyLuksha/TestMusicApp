using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
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
