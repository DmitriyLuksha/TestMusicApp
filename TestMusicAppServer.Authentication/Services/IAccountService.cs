using System;
using System.Threading.Tasks;
using TestMusicAppServer.Authentication.Contexts;
using TestMusicAppServer.Common.Contracts;

namespace TestMusicAppServer.Authentication.Services
{
    public interface IAccountService : IService
    {
        Task SignIn(AuthenticationContext context, Guid id, string username, string email);

        Task SignOut(AuthenticationContext context);
    }
}
