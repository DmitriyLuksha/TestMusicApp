using MediatR;

namespace TestMusicAppServer.Shared.Domain.Queries
{
    public abstract class BaseQuery<T> : IRequest<T>
    {
    }
}
