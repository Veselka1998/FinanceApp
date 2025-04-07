using FinanceApp.Components.Data;
using FinanceApp.Components.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Components.Services;

public class FinanceProductService
{
    private readonly AppDbContext _context;

    public FinanceProductService(AppDbContext context)
    {
        _context = context;
        _context.Database.EnsureCreated();
    }

    public async Task<List<FinanceProduct>> GetFinanceProductsAsync()
    {
        return await _context.FinanceProducts.ToListAsync();
    }

    public async Task AddFinanceProductAsync(FinanceProduct financeProduct)
    {
        _context.FinanceProducts.Add(financeProduct);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteFinanceProductAsync(uint id)
    {
        var financeProduct = await _context.FinanceProducts.FindAsync(id);
        if (financeProduct != null)
        {
            _context.FinanceProducts.Remove(financeProduct);
            await _context.SaveChangesAsync();
        }
    }
}
