using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestMusicAppServer.Authentication.Contexts;
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

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] AddUserCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> SignIn([FromBody] SignInCommand command)
        {
            command.Context = new AuthenticationContext(HttpContext);

            await _mediator.Send(command);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("signout")]
        public async Task<IActionResult> SignOut()
        {
            var command = new SignOutCommand
            {
                Context = new AuthenticationContext(HttpContext)
            };

            await _mediator.Send(command);
            return Ok();
        }
    }
}
