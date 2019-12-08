using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TestMusicAppServer.Api.ApiResults;

namespace TestMusicAppServer.Api.Handlers
{
    public static class InvalidModelStateHandler
    {
        public static IActionResult FormatResponse(ActionContext context)
        {
            var errorMessage = FormatErrorMessage(context);

            var result = new ApiResult
            {
                Success = false,
                ErrorMessage = errorMessage
            };

            return new BadRequestObjectResult(result);
        }

        private static string FormatErrorMessage(ActionContext context)
        {
            var errors = context.ModelState
                .SelectMany(s =>
                    s.Value.Errors
                        .Select(e => e.ErrorMessage));
            
            var errorMessage = string.Join(Environment.NewLine, errors);
            return errorMessage;
        }
    }
}
