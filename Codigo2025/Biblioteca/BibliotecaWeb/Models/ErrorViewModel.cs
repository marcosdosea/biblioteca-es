using System.Diagnostics;

namespace BibliotecaWeb.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string? Message {  get; set; }

        public string? StackTrace { get; set; }
    }
}
