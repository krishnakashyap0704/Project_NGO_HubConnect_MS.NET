using Project_NGO_HubConnect.Models;

namespace NGO_HubConnect.Models
{
    public class Enrollment
    {
        public string Email { get; set; }
        public ApplicationUser User { get; set; }
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string Location { get; set; }
        public Event Event { get; set; }
    }
}
