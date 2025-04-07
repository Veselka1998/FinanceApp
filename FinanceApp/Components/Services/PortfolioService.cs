using FinanceApp.Components.Data;
using FinanceApp.Components.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Components.Services;

public class PortfolioService
{
    private readonly AppDbContext _context;

    public PortfolioService(AppDbContext context)
    {
        _context = context;
        _context.Database.EnsureCreated();
    }

    public async Task<List<Portfolio>> GetPortfoliosAsync()
    {
        return await _context.Portfolios.ToListAsync();
    }

    public async Task AddPortfolioAsync(Portfolio portfolio)
    {
        _context.Portfolios.Add(portfolio);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePortfolioAsync(uint id)
    {
        var portfolio = await _context.Portfolios
           .Include(p => p.FinanceProducts).FirstOrDefaultAsync(p => p.Id == id);

        if (portfolio != null)
        {
            _context.FinanceProducts.RemoveRange(portfolio.FinanceProducts);
            _context.Portfolios.Remove(portfolio);
            await _context.SaveChangesAsync();
        }
    }
    public async Task<Portfolio> GetPortfolioByIdAsync(uint id)
    {
        return await _context.Portfolios.FirstOrDefaultAsync(item => item.Id == id);
    }
}
