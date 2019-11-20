using System;

namespace TestMusicAppServer.Api.ApiResults
{
    public class ApiResult
    {
        public bool Success { get; set; }

        public string ErrorMessage { get; set; }

        public object Data { get; set; }

        public Exception Exception { get; set; }
    }
}
