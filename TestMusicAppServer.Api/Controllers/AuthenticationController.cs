using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestMusicAppServer.User.Domain.Commands;

namespace TestMusicAppServer.Api.Controllers
{
    [Route("api/authentication")]
    public class AuthenticationController : BaseApiController
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> SignIn([FromBody] SignInCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost]
        [Route("signout")]
        public async Task<IActionResult> SignOut()
        {
            var command = new SignOutCommand();

            await _mediator.Send(command);
            return Ok();
        }
    }
}
