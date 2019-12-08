using System;
using System.Threading.Tasks;
using TestMusicAppServer.Authentication.Contexts;
using TestMusicAppServer.Common.Contracts;

namespace TestMusicAppServer.Authentication.Services
{
    public interface IAccountService : IService
    {
        Task Authenticate(AuthenticationContext context, Guid id, string username, string email);
    }
}
