using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestMusicAppServer.Authentication.Services;
using TestMusicAppServer.Track.Domain.Commands;
using TestMusicAppServer.Track.Domain.Queries;

namespace TestMusicAppServer.Api.Controllers
{
    [Route("api/tracks")]
    public class TracksController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly IAccountService _accountService;

        public TracksController(IMediator mediator, IAccountService accountService)
        {
            this._mediator = mediator;
            this._accountService = accountService;
        }

        [HttpPost]
        [Route("uploadFile")]
        [RequestSizeLimit(30 * 1000 * 1000)]
        public async Task<IActionResult> UploadFile([FromForm] UploadFileCommand command)
        {
            command.UserId = _accountService.UserId;
            command.File = new MemoryStream();

            await Request.Form.Files[0].CopyToAsync(command.File);

            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        [Route("getForPlaylist")]
        public async Task<IActionResult> GetTracksForPlaylist([FromQuery] GetTracksByPlaylistQuery query)
        {
            var tracks = await _mediator.Send(query);

            var trackCleaned = tracks.Select(t => new
            {
                t.Id,
                t.PlaylistId,
                t.TrackName
            });

            return Ok(trackCleaned);
        }
    }
}
