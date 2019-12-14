using System.Threading;
using System.Threading.Tasks;
using TestMusicAppServer.Authentication.Services;
using TestMusicAppServer.Shared.Domain.CommandHandlers;
using TestMusicAppServer.User.Domain.Commands;

namespace TestMusicAppServer.User.Domain.CommandHandlers
{
    public class SignOutCommandHandler : BaseCommandHandler<SignOutCommand>
    {
        private IAccountService _accountService;

        public SignOutCommandHandler(IAccountService accountService)
        {
            this._accountService = accountService;
        }

        protected override Task Handle(SignOutCommand command, CancellationToken cancellationToken)
        {
            return _accountService.SignOut();
        }
    }
}
