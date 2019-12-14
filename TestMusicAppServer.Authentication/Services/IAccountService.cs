using System;
using System.Threading.Tasks;
using TestMusicAppServer.Common.Contracts;

namespace TestMusicAppServer.Authentication.Services
{
    public interface IAccountService : IService
    {
        Task SignIn(Guid id, string username, string email);

        Task SignOut();

        Guid UserId { get; }

        string UserName { get; }

        string UserEmail { get; }
    }
}
