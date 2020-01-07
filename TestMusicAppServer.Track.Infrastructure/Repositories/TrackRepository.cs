using TestMusicAppServer.Shared.Infrastructure.Repositories;
using TestMusicAppServer.Track.Infrastructure.Contexts;

namespace TestMusicAppServer.Track.Infrastructure.Repositories
{
    public class TrackRepository : BaseRepository<Domain.Entities.Track>
    {
        public TrackRepository(TrackContext context)
            : base(context)
        {
        }
    }
}
