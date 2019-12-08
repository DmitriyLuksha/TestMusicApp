using TestMusicAppServer.Authentication.Contexts;
using TestMusicAppServer.Shared.Domain.Commands;

namespace TestMusicAppServer.User.Domain.Commands
{
    public class SignInCommand : BaseCommand
    {
        public AuthenticationContext Context { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
