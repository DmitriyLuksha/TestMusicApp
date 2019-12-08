using Microsoft.AspNetCore.Http;

namespace TestMusicAppServer.Authentication.Contexts
{
    public class AuthenticationContext
    {
        public AuthenticationContext(HttpContext context)
        {
            this.HttpContext = context;
        }

        public HttpContext HttpContext { get; set; }
    }
}
