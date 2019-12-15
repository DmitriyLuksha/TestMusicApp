using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Net;
using System.Threading.Tasks;
using TestMusicAppServer.Api.ApiResults;
using TestMusicAppServer.Api.Extensions;

namespace TestMusicAppServer.Api.Handlers
{
    public static class UserNotAuthenticatedHandler
    {
        public static Task Handle(RedirectContext<CookieAuthenticationOptions> context)
        {
            var result = new ApiResult()
            {
                Success = false,
                ErrorMessage = "User is not authenticated"
            };

            return context.Response.FormatResultAsync(result, HttpStatusCode.Unauthorized);
        }
    }
}
