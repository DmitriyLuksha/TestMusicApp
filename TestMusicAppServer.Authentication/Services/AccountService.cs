using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using TestMusicAppServer.Authentication.Contexts;

namespace TestMusicAppServer.Authentication.Services
{
    public class AccountService : IAccountService
    {
        public Task SignIn(AuthenticationContext context, Guid id, string username, string email)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, username)
            };

            var identity = new ClaimsIdentity(claims, 
                "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            return context.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity));
        }

        public Task SignOut(AuthenticationContext context)
        {
            return context.HttpContext.SignOutAsync();
        }
    }
}
