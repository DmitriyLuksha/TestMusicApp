using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestMusicAppServer.Authentication.Services;
using TestMusicAppServer.Playlist.Domain.Commands;
using TestMusicAppServer.Playlist.Domain.Queries;

namespace TestMusicAppServer.Api.Controllers
{
    [Route("api/playlists")]
    public class PlaylistController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly IAccountService _accountService;

        public PlaylistController(IMediator mediator, IAccountService accountService)
        {
            this._mediator = mediator;
            this._accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlaylist([FromBody] AddPlaylistCommand command)
        {
            command.UserId = _accountService.UserId;

            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetPlaylists()
        {
            var query = new GetPlaylistsForUserQuery
            {
                UserId = _accountService.UserId
            };

            var playlists = await _mediator.Send(query);
            return Ok(playlists);
        }
    }
}
