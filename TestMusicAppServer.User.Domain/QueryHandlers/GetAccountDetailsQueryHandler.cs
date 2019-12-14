using System.Threading;
using System.Threading.Tasks;
using TestMusicAppServer.Authentication.Services;
using TestMusicAppServer.Shared.Domain.QueryHandlers;
using TestMusicAppServer.User.Domain.Dto;
using TestMusicAppServer.User.Domain.Queries;

namespace TestMusicAppServer.User.Domain.QueryHandlers
{
    public class GetAccountDetailsQueryHandler : BaseQueryHandler<GetAccountDetailsQuery, AccountDetailsDto>
    {
        private readonly IAccountService _accountService;

        public GetAccountDetailsQueryHandler(IAccountService accountService)
        {
            this._accountService = accountService;
        }

        public override Task<AccountDetailsDto> Handle(GetAccountDetailsQuery query, CancellationToken cancellationToken)
        {
            var accountDetails = new AccountDetailsDto
            {
                Id = _accountService.UserId,
                Email = _accountService.UserEmail,
                UserName = _accountService.UserName
            };

            return Task.FromResult(accountDetails);
        }
    }
}
