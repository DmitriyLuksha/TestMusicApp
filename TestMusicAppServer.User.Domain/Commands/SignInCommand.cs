using TestMusicAppServer.Shared.Domain.Commands;

namespace TestMusicAppServer.User.Domain.Commands
{
    public class SignInCommand : BaseCommand
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
