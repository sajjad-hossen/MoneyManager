using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [StringLength(20)]
        public string? MobileNumber { get; set; }

        [StringLength(100)]
        public string? Country { get; set; }
    }
}
