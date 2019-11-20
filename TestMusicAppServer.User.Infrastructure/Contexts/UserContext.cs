using Microsoft.EntityFrameworkCore;

namespace TestMusicAppServer.User.Infrastructure.Contexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.Entities.User> Users { get; set; }
    }
}
