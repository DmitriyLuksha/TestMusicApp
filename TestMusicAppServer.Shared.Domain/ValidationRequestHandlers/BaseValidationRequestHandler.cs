using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TestMusicAppServer.Shared.Domain.ValidationRequests;
using TestMusicAppServer.Shared.Domain.ValidationResponses;

namespace TestMusicAppServer.Shared.Domain.ValidationRequestHandlers
{
    public abstract class BaseValidationRequestHandler<T> : IRequestHandler<T, ValidationResponse>
        where T : IValidationRequest
    {
        public abstract Task<ValidationResponse> Handle(T request, CancellationToken cancellationToken);
    }
}
