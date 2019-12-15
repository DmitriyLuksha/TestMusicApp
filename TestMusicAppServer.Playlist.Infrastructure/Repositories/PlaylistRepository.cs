using TestMusicAppServer.Playlist.Infrastructure.Contexts;
using TestMusicAppServer.Shared.Infrastructure.Repositories;

namespace TestMusicAppServer.Playlist.Infrastructure.Repositories
{
    public class PlaylistRepository : BaseRepository<Domain.Entities.Playlist>
    {
        public PlaylistRepository(PlaylistContext context)
            : base(context)
        {
        }
    }
}
