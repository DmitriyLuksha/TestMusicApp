using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestMusicAppServer.User.Domain.Commands;
using TestMusicAppServer.User.Domain.Queries;

namespace TestMusicAppServer.Api.Controllers
{
    [Route("api/account")]
    public class AccountController : BaseApiController
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] AddUserCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("isUsernameUnique")]
        public async Task<IActionResult> IsUsernameUnique([FromQuery] IsUsernameUniqueQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("isEmailUnique")]
        public async Task<IActionResult> IsEmailUnique([FromQuery] IsEmailUniqueQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("details")]
        public async Task<IActionResult> GetAccountDetails()
        {
            var query = new GetAccountDetailsQuery();
            var details = await _mediator.Send(query);

            return Ok(details);
        }
    }
}
