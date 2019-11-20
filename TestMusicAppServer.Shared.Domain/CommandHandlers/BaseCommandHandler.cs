using MediatR;
using TestMusicAppServer.Shared.Domain.Commands;

namespace TestMusicAppServer.Shared.Domain.CommandHandlers
{
    public abstract class BaseCommandHandler<T> : AsyncRequestHandler<T>
        where T: BaseCommand
    {
    }
}
