using MediatR;

namespace TestMusicAppServer.Shared.Domain.Queries
{
    public interface IQuery<T> : IRequest<T>
    {
    }
}
