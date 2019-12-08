using TestMusicAppServer.Authentication.Contexts;
using TestMusicAppServer.Shared.Domain.Commands;

namespace TestMusicAppServer.User.Domain.Commands
{
    public class SignOutCommand : BaseCommand
    {
        public AuthenticationContext Context { get; set; }
    }
}
