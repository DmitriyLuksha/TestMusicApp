using System.Threading;
using System.Threading.Tasks;
using TestMusicAppServer.Shared.Domain.CommandHandlers;
using TestMusicAppServer.Shared.Domain.Contracts;
using TestMusicAppServer.Track.Domain.Commands;

namespace TestMusicAppServer.Track.Domain.CommandHandlers
{
    public class AddTrackCommandHandler : BaseCommandHandler<AddTrackCommand>
    {
        public AddTrackCommandHandler(IRepository<Entities.Track> repository)
        {
            this._repository = repository;
        }

        private readonly IRepository<Entities.Track> _repository;

        protected override async Task Handle(AddTrackCommand command, CancellationToken cancellationToken)
        {
            var track = new Entities.Track(
                command.TrackId,
                command.PlaylistId,
                command.TrackName,
                command.FileName);

            await _repository.CreateAsync(track);
        }
    }
}
