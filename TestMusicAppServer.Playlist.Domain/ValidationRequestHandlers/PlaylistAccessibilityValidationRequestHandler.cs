using System.Threading;
using System.Threading.Tasks;
using TestMusicAppServer.Playlist.Definitions.ValidationRequests;
using TestMusicAppServer.Resources;
using TestMusicAppServer.Shared.Domain.Contracts;
using TestMusicAppServer.Shared.Domain.ValidationRequestHandlers;
using TestMusicAppServer.Shared.Domain.ValidationResponses;

namespace TestMusicAppServer.Playlist.Domain.ValidationRequestHandlers
{
    public class PlaylistAccessibilityValidationRequestHandler
        : BaseValidationRequestHandler<PlaylistAccessibilityValidationRequest>
    {
        private readonly IRepository<Entities.Playlist> _repository;

        public PlaylistAccessibilityValidationRequestHandler(IRepository<Entities.Playlist> repository)
        {
            this._repository = repository;
        }

        public override async Task<ValidationResponse> Handle(PlaylistAccessibilityValidationRequest request,
            CancellationToken cancellationToken)
        {
            var playlist = await _repository.GetByIdAsync(request.PlaylistId);

            if (playlist == null)
            {
                return ValidationResponse.GetInvalidResponse(InvalidityReasons.PlaylistUnknown);
            }

            if (playlist.UserId != request.UserId)
            {
                return ValidationResponse.GetInvalidResponse(InvalidityReasons.PlaylistInaccessible);
            }

            return ValidationResponse.GetValidResponse();
        }
    }
}
