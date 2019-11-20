using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestMusicAppServer.User.Domain.Commands;
using TestMusicAppServer.User.Domain.Queries;

namespace TestMusicAppServer.Api.Controllers
{
    [Route("api/users")]
    public class UserController : BaseApiController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        
        [HttpGet]
        [Route("isUsernameUnique")]
        public async Task<IActionResult> IsUsernameUnique([FromQuery] IsUsernameUniqueQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("isEmailUnique")]
        public async Task<IActionResult> IsEmailUnique([FromQuery] IsEmailUniqueQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] AddUserCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
