using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TestMusicAppServer.Shared.Domain.Queries;

namespace TestMusicAppServer.Shared.Domain.QueryHandlers
{
    public abstract class BaseQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
        where TQuery: BaseQuery<TResponse>
    {
        public abstract Task<TResponse> Handle(TQuery query, CancellationToken cancellationToken);
    }
}
