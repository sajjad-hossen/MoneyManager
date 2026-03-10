using Microsoft.EntityFrameworkCore;
using MoneyManager.Data;
using MoneyManager.Repositories;
using MoneyManager.Managers;
using System.Globalization;

// Set global culture to Bangladesh (bn-BD) with custom currency symbol 'tk'
var cultureInfo = new CultureInfo("bn-BD");
cultureInfo.NumberFormat.CurrencySymbol = "tk";
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllersWithViews();

// Register Repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
builder.Services.AddScoped<IIncomeRepository, IncomeRepository>();

// Register Managers
builder.Services.AddScoped<ICategoryManager, CategoryManager>();
builder.Services.AddScoped<IExpenseManager, ExpenseManager>();
builder.Services.AddScoped<IIncomeManager, IncomeManager>();
builder.Services.AddScoped<IDashboardManager, DashboardManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
