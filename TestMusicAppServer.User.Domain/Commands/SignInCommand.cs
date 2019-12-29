using TestMusicAppServer.Shared.Domain.Commands;

namespace TestMusicAppServer.User.Domain.Commands
{
    public class SignInCommand : ICommand
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
