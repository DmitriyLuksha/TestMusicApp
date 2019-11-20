using TestMusicAppServer.Shared.Infrastructure.Repositories;
using TestMusicAppServer.User.Infrastructure.Contexts;

namespace TestMusicAppServer.User.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<Domain.Entities.User>
    {
        public UserRepository(UserContext context)
            : base(context)
        {
        }
    }
}
