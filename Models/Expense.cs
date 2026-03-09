using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyManager.Models
{
    public class Expense
    {
        public int Id { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public decimal Amount { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Description { get; set; } = string.Empty;
        
        [Required]
        public DateTime Date { get; set; } = DateTime.Now;
        
        [Required]
        public int CategoryId { get; set; }
        
        public virtual Category? Category { get; set; }
        
        public string? Note { get; set; }
    }
}
