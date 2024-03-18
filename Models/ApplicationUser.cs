using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using NGO_HubConnect.Models;

namespace Project_NGO_HubConnect.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Enrollment> UserEvents { get; set; }
    }
}
