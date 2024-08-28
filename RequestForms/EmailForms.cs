using Microsoft.AspNetCore.Mvc;

namespace virtual_ex.RequestForms
{
    public class SendMailForm
    {
        public required string Subject { get; set; }
        public required string Body { get; set; }
        public required IEnumerable<string> To { get; set; }
    }


    public class RequestEmailConfirmation
    {
        public required string Email { get; set; }
    }
}
