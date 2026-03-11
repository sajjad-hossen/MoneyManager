using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyManager.Models
{
    public class Income
    {
        public int Id { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public decimal Amount { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Source { get; set; } = string.Empty;
        
        [Required]
        public DateTime Date { get; set; } = DateTime.Now;
        
        public string? Note { get; set; }

        public string? UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }
    }
}
