using NGO_HubConnect.Models;
using System.ComponentModel.DataAnnotations;


namespace Project_NGO_HubConnect.Models
{
    public class Event
    {
        [Key]
        public int Event_ID { get; set; }

        [Required(ErrorMessage = "The Image path is required")]
        [StringLength(255)]
        public string Image { get; set; }

        [Required(ErrorMessage = "The Event name field is required.")]
        [StringLength(100, ErrorMessage = "Event name cannot exceed 100 characters.")]
        [Display(Name = "Event Name")]
        public string Event_Name { get; set; }

        [Required(ErrorMessage = "The Organisation name field is required.")]
        [StringLength(150, ErrorMessage = "Organisation name cannot exceed 150 characters.")]
        [Display(Name = "Organization Name")]
        public string Organisation_Name { get; set; }
 
        [Required(ErrorMessage = "The Date and time field is required")]
        [NotPastDate(ErrorMessage = "Event Date cannot be a past date.")]
        [Display(Name = "Date And Time")]
        public DateTime? DateTime { get; set; }

        [Required(ErrorMessage = "The Phone field is required")]
        [RegularExpression(@"^9[0-9]+$", ErrorMessage = "Phone numbers should only consist of digits and start with 9.")]
        [StringLength(10, ErrorMessage = "Phone number cannot exceed 10 characters.")]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [StringLength(100, ErrorMessage = "Location cannot exceed 100 characters.")]
        [Required(ErrorMessage = "The Location field is required")]
        public string Location { get; set; }

        [StringLength(100, ErrorMessage = "Event type cannot exceed 100 characters.")]
        [Required(ErrorMessage = "The Event type is required")]
        [Display(Name = "Event Type")]
        public string EventType { get; set; }

        [StringLength(255, ErrorMessage = "Description cannot exceed 255 characters.")]
        public string Description { get; set; }

        public ICollection<Enrollment> UserEvents { get; set; }

    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class NotPastDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime date)
            {
                return date >= DateTime.Now;
            }

            // Return false for non-DateTime values (you can modify this behavior based on your requirements)
            return false;
        }
    }
}
