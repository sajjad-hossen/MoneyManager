namespace MoneyManager.Models
{
    public class DashboardViewModel
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal NetSavings => TotalIncome - TotalExpenses;
        
        public List<Income> RecentIncomes { get; set; } = new();
        public List<Expense> RecentExpenses { get; set; } = new();
        
        public List<CategorySummary> CategoryBreakdown { get; set; } = new();
    }

    public class CategorySummary
    {
        public string CategoryName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Color { get; set; } = string.Empty;
        public double Percentage { get; set; }
    }
}
