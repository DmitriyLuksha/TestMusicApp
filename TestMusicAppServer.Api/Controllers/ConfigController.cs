using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TestMusicAppServer.Common.Configurations;

namespace TestMusicAppServer.Api.Controllers
{
    [Route("api/config")]
    public class ConfigController : BaseApiController
    {
        private readonly ApplicationInsightsConfig _applicationInsightsConfig;

        public ConfigController(IOptions<ApplicationInsightsConfig> applicationInsightsConfig)
        {
            this._applicationInsightsConfig = applicationInsightsConfig.Value;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("applicationInsightInstrumentationKey")]
        public IActionResult GetApplicationInsightInstrumentationKey()
        {
            // For now controller finds config values itself
            // We should switch to queries in case if we need more complex logic
            // than just reading property
            return Ok(_applicationInsightsConfig.InstrumentationKey);
        }
    }
}
