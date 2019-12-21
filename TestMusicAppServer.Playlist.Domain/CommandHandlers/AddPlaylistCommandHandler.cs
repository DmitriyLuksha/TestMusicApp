using System.Threading;
using System.Threading.Tasks;
using TestMusicAppServer.Playlist.Domain.Commands;
using TestMusicAppServer.Shared.Domain.CommandHandlers;
using TestMusicAppServer.Shared.Domain.Contracts;

namespace TestMusicAppServer.Playlist.Domain.CommandHandlers
{
    public class AddPlaylistCommandHandler : BaseCommandHandler<AddPlaylistCommand>
    {
        public AddPlaylistCommandHandler(IRepository<Entities.Playlist> repository)
        {
            this._repository = repository;
        }

        private readonly IRepository<Entities.Playlist> _repository;
        
        protected override async Task Handle(AddPlaylistCommand command, CancellationToken cancellationToken)
        {
            var playlist = new Entities.Playlist(command.PlaylistId, command.Name, command.UserId);

            await _repository.CreateAsync(playlist);
        }
    }
}
