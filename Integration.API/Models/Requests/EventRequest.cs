using Integration.API.Models;
using System.Collections.Generic;

namespace Integration.API.Requests
{
    public class EventRequest
	{
        public string Subject { get; set; }
        public Body Body { get; set; }
        public Time Start { get; set; }
        public Time End { get; set; }
        public LocationRequest Location { get; set; }
        public List<AttendeeRequest> Attendees { get; set; }
        public bool AllowNewTimeProposals { get; set; }
        public string TransactionId { get; set; }
    }
}