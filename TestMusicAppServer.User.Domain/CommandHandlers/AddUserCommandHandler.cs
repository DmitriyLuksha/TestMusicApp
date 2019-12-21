using System;
using System.Threading;
using System.Threading.Tasks;
using TestMusicAppServer.Shared.Domain.CommandHandlers;
using TestMusicAppServer.Shared.Domain.Contracts;
using TestMusicAppServer.User.Domain.Commands;

namespace TestMusicAppServer.User.Domain.CommandHandlers
{
    public class AddUserCommandHandler: BaseCommandHandler<AddUserCommand>
    {
        public AddUserCommandHandler(IRepository<Entities.User> repository)
        {
            this._repository = repository;
        }

        private readonly IRepository<Entities.User> _repository;

        protected override async Task Handle(AddUserCommand command, CancellationToken cancellationToken)
        {
            var user = new Entities.User(command.UserId,
                command.Email,
                command.Username,
                command.Password);

            await _repository.CreateAsync(user);
        }
    }
}
