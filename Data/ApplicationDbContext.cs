using Microsoft.EntityFrameworkCore;
using MoneyManager.Models;

namespace MoneyManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed some default categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Food & Drinks", Icon = "bi-cup-hot", Color = "#FF5733" },
                new Category { Id = 2, Name = "Rent & Bills", Icon = "bi-house", Color = "#33FF57" },
                new Category { Id = 3, Name = "Transport", Icon = "bi-car-front", Color = "#3357FF" },
                new Category { Id = 4, Name = "Shopping", Icon = "bi-bag", Color = "#F333FF" },
                new Category { Id = 5, Name = "Entertainment", Icon = "bi-controller", Color = "#FFB833" },
                new Category { Id = 6, Name = "Health", Icon = "bi-heart-pulse", Color = "#FF3333" },
                new Category { Id = 7, Name = "Other", Icon = "bi-tag", Color = "#999999" }
            );
        }
    }
}
