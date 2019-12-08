using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TestMusicAppServer.Api.ApiResults;
using TestMusicAppServer.Common.Constants;

namespace TestMusicAppServer.Api.Helpers
{
    public static class ResponseFormatter
    {
        public static Task FormatResult(this HttpResponse response, ApiResult apiResult, HttpStatusCode code)
        {
            response.StatusCode = (int)code;
            response.ContentType = MimeTypes.Application.Json;

            var result = JsonConvert.SerializeObject(apiResult,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore
                });

            return response.WriteAsync(result);
        }
    }
}
