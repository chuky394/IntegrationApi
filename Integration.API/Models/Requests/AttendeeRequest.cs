using Integration.API.Models;

namespace Integration.API.Requests
{
    public class AttendeeRequest
    {
        public EmailAddress EmailAddress { get; set; }
        public string Type { get; set; }
    }
}