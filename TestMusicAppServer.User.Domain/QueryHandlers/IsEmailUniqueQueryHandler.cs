using System.Threading;
using System.Threading.Tasks;
using TestMusicAppServer.Shared.Domain.Contracts;
using TestMusicAppServer.Shared.Domain.QueryHandlers;
using TestMusicAppServer.User.Domain.Queries;

namespace TestMusicAppServer.User.Domain.QueryHandlers
{
    public class IsEmailUniqueQueryHandler : BaseQueryHandler<IsEmailUniqueQuery, bool>
    {
        public IsEmailUniqueQueryHandler(IRepository<Entities.User> repository)
        {
            this._repository = repository;
        }

        private readonly IRepository<Entities.User> _repository;

        public override async Task<bool> Handle(IsEmailUniqueQuery query, CancellationToken cancellationToken)
        {
            var user = await _repository.FindSingleAsync(u => u.Email == query.Email);

            return user == null;
        }
    }
}
