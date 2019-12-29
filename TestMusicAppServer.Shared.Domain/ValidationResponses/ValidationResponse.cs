using TestMusicAppServer.Resources;

namespace TestMusicAppServer.Shared.Domain.ValidationResponses
{
    public class ValidationResponse
    {
        private ValidationResponse() { }

        public static ValidationResponse GetValidResponse()
        {
            return new ValidationResponse
            {
                IsValid = true
            };
        }

        // Don't pass invalidityReason with sensitive data
        public static ValidationResponse GetInvalidResponse(string invalidityReason = null)
        {
            return new ValidationResponse
            {
                IsValid = false,
                InvalidityReason = invalidityReason ?? InvalidityReasons.ValueInvalid
            };
        }

        public bool IsValid { get; private set; }

        public string InvalidityReason { get; private set; }

        // TODO Add value to identify invalidity reasons programmatically
    }
}
