using Microsoft.EntityFrameworkCore;

namespace TestMusicAppServer.Track.Infrastructure.Contexts
{
    public class TrackContext : DbContext
    {
        public TrackContext(DbContextOptions<TrackContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.Entities.Track> Tracks { get; set; }
    }
}
