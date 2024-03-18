using Microsoft.EntityFrameworkCore;
using Project_NGO_HubConnect.Data;
using System.ComponentModel.DataAnnotations;

namespace Project_NGO_HubConnect.Models
{
    public class Ngo
    {
        [Key]
        public int NGO_id { get; set; }

        [Required(ErrorMessage = "Organization name is required.")]
        [StringLength(150, ErrorMessage = "Organization name cannot exceed 150 characters.")]
        [Display(Name = "Name Of Organisation")]
        public string Organization_Name { get; set; }

        [Required(ErrorMessage = "Darpan ID is required.")]
        [StringLength(10, ErrorMessage = "Darpan ID cannot exceed 20 characters.")]
        [RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "Darpan ID must contain only alphanumeric characters.")]
        [Display(Name = "Darpan ID")]
        public string Darpan_ID { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(50, ErrorMessage = "Email cannot exceed 50 characters.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public string Vision { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        [RegularExpression(@"^9[0-9]+$", ErrorMessage = "Phone numbers should only consist of digits and start with 9.")]
        [StringLength(10, ErrorMessage = "Phone number cannot exceed 10 characters.")]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(255, ErrorMessage = "Address cannot exceed 255 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Website is required.")]
        [StringLength(255, ErrorMessage = "Website URL cannot exceed 255 characters.")]
        [RegularExpression(@"^(http|https)://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,}(\/\S*)?$", ErrorMessage = "Invalid website URL.")]
        public string Website { get; set; }

        [Required(ErrorMessage = "Year of establisment is required.")]
        [Range(1800, 2024, ErrorMessage = "Invalid year of establishment.")]
        [Display(Name = "Year Of Establishment")]
        public int? YearOfEstablishment { get; set; }

        [Required(ErrorMessage = "Key focus areas is required.")]
        [StringLength(255, ErrorMessage = "Key focus areas cannot exceed 255 characters.")]
        [Display(Name = "Key Focus Areas")]
        public string KeyFocusAreas { get; set; }

        [Display(Name = "Is Approved")]
        public bool IsApproved { get; set; }
    }

}
