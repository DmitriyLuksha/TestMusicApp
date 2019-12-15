using Microsoft.EntityFrameworkCore;

namespace TestMusicAppServer.Playlist.Infrastructure.Contexts
{
    public class PlaylistContext : DbContext
    {
        public PlaylistContext(DbContextOptions<PlaylistContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.Entities.Playlist> Playlists { get; set; }
    }
}
