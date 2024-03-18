using System.ComponentModel.DataAnnotations;

namespace NGO_HubConnect.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "The Name field is required")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Name should only contain alphabets.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Phone field is required")]
        [RegularExpression(@"^9[0-9]+$", ErrorMessage = "Phone numbers should only consist of digits and start with 9.")]
        [StringLength(10, ErrorMessage = "Phone number cannot exceed 10 characters.")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(50, ErrorMessage = "Email cannot exceed 50 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(500, double.MaxValue, ErrorMessage = "Amount must be greater than 500.")]
        public decimal Amount { get; set; }
    }
}
