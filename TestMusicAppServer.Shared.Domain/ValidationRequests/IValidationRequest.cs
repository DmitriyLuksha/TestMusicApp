using MediatR;
using TestMusicAppServer.Shared.Domain.ValidationResponses;

namespace TestMusicAppServer.Shared.Domain.ValidationRequests
{
    public interface IValidationRequest : IRequest<ValidationResponse>
    {
    }
}
