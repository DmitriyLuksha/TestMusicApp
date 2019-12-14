using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TestMusicAppServer.Common.Exceptions;

namespace TestMusicAppServer.Authentication.Services
{
    public class AccountService : IAccountService
    {
        private readonly IHttpContextAccessor _context;

        public AccountService(IHttpContextAccessor context)
        {
            _context = context;
        }

        public Task SignIn(Guid id, string username, string email)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, username),
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                new Claim(ClaimTypes.Email, email)
            };

            var identity = new ClaimsIdentity(claims, 
                "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            return _context.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity));
        }

        public Task SignOut()
        {
            return _context.HttpContext.SignOutAsync();
        }
        
        public Guid UserId => Guid.Parse(GetClaimValue(ClaimTypes.NameIdentifier));

        public string UserName => GetClaimValue(ClaimsIdentity.DefaultNameClaimType);

        public string UserEmail => GetClaimValue(ClaimTypes.Email);

        private string GetClaimValue(string claimType)
        {
            var claim = _context.HttpContext.User.Claims
                .FirstOrDefault(c => c.Type == claimType);

            if (claim == null)
            {
                throw new UserNotLoggedInException();
            }

            return claim.Value;
        }
    }
}
