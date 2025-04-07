using FinanceApp.Components.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FinanceApp.Components.Data;

public class AppDbContext : DbContext
{
    public DbSet<Portfolio> Portfolios { get; set; }
    public DbSet<Note> Notes { get; set; }
    public DbSet<FinanceProduct> FinanceProducts { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "financeAppDatabase2.db");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
