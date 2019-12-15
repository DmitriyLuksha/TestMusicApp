using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using TestMusicAppServer.Api.ApiResults;
using TestMusicAppServer.Api.Extensions;
using TestMusicAppServer.Resources;

namespace TestMusicAppServer.Api.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context, IHostingEnvironment env)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // var showExceptionObject = env.IsDevelopment();
                var showExceptionObject = true;
                await HandleExceptionAsync(context, ex, showExceptionObject);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception, bool showExceptionObject)
        {
            var errorMessage = "";
            HttpStatusCode statusCode;

            if (exception is ValidationException)
            {
                errorMessage = exception.Message;
                statusCode = HttpStatusCode.BadRequest;
            }
            else
            {
                errorMessage = ResExceptionMessage.AnErrorHasOccurred;
                statusCode = HttpStatusCode.InternalServerError;
            }

            var result = new ApiResult
            {
                Success = false,
                ErrorMessage = errorMessage,
                Exception = showExceptionObject ? exception : null
            };

            return context.Response.FormatResultAsync(result, statusCode);
        }
    }
}
