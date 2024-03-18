using Project_NGO_HubConnect.Data;
using System.ComponentModel.DataAnnotations;

namespace Project_NGO_HubConnect.Models
{
    public class Volunteer
    {
        [Key]
        public int Volunteer_ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Name should only contain alphabets.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        [CustomDateOfBirthValidation(ErrorMessage = "Date of Birth must be greater than 1900 and smaller than the current date.")]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [RegularExpression(@"^9[0-9]+$", ErrorMessage = "Phone numbers should only consist of digits and start with 9.")]
        [StringLength(10, ErrorMessage = "Phone number cannot exceed 10 characters.")]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(255)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(150, ErrorMessage = "Address cannot exceed 150 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Occupation is required")]
        [StringLength(100, ErrorMessage = "Occupation cannot exceed 100 characters.")]
        public string Occupation { get; set; }

        [Required(ErrorMessage = "Education is required")]
        [StringLength(100, ErrorMessage = "Education cannot exceed 100 characters.")]
        public string Education { get; set; }

        [Required(ErrorMessage = "Interest is required")]
        [StringLength(100, ErrorMessage = "Interest cannot exceed 150 characters.")]
        public string Interest { get; set; }

        [Required(ErrorMessage = "Language is required")]
        [StringLength(100, ErrorMessage = "Language cannot exceed 100 characters.")]
        public string Language { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Invalid password. It must have at least 8 characters, including uppercase, lowercase, digit, and special character.")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public class CustomDateOfBirthValidationAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value is DateTime dateOfBirth)
                {
                    // Check if the date is greater than 1900 and smaller than the current date
                    if (dateOfBirth.Year > 1900 && dateOfBirth < DateTime.Now)
                    {
                        return ValidationResult.Success;
                    }
                }

                return new ValidationResult(ErrorMessage);
            }
        }
    }

}
