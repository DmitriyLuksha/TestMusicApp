using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using TestMusicAppServer.Authentication.Services;
using TestMusicAppServer.Shared.Domain.CommandHandlers;
using TestMusicAppServer.Shared.Domain.Contracts;
using TestMusicAppServer.User.Domain.Commands;
using TestMusicAppServer.User.Domain.Helpers;

namespace TestMusicAppServer.User.Domain.CommandHandlers
{
    public class SignInCommandHandler : BaseCommandHandler<SignInCommand>
    {
        public SignInCommandHandler(IAccountService accountService,
            IRepository<Entities.User> repository)
        {
            this._accountService = accountService;
            this._repository = repository;
        }

        private readonly IAccountService _accountService;
        private readonly IRepository<Entities.User> _repository;

        protected override async Task Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.FindSingleAsync((u) => u.Username == request.Username);

            if (user == null)
            {
                throw new ValidationException("Unknown user");
            }

            var hashedPassword = PasswordHashProvider.ComputeHash(request.Password);

            if (hashedPassword != user.Password)
            {
                throw new ValidationException("Invalid password");
            }

            await _accountService.SignIn(request.Context, user.Id, user.Username, user.Email);
        }
    }
}
