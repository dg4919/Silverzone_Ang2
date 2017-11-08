using System;

namespace Silverzone.Entities
{
    public class ErrorLogs : Entity<int>
    {
        public int ErrorCode { get; set; }
        public DateTime ErrorDate { get; set; }
        public string ErrorModule { get; set; }

        public string ErrorURL { get; set; }
        public string ErrorSource { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorStackTrace { get; set; }

        public string ErrorInnerException { get; set; }
        public string ErrorIP { get; set; }
        public string ErrorBrowser { get; set; }
        public string ErrorBrowserVersion { get; set; }
        public string ErrorOperatingSystem { get; set; }
        public string ErrorLocation { get; set; }
    }
}
