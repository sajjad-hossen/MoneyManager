using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Models
{
    public class Category
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        
        public string Icon { get; set; } = "bi-tag"; // Bootstrap icons as default
        
        public string Color { get; set; } = "#6c757d"; // Hex color
        
        public virtual ICollection<Expense>? Expenses { get; set; }

        public string? UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }
    }
}
