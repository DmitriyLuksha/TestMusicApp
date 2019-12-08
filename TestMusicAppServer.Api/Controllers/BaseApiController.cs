using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestMusicAppServer.Api.ApiResults;

namespace TestMusicAppServer.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class BaseApiController : ControllerBase
    {
        [NonAction]
        public override OkObjectResult Ok(object value)
        {
            return base.Ok(new ApiResult()
            {
                Success = true,
                Data = value
            });
        }

        [NonAction]
        public new OkObjectResult Ok()
        {
            return base.Ok(new ApiResult()
            {
                Success = true
            });
        }
    }
}
