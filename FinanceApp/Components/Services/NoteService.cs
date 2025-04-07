using FinanceApp.Components.Data;
using FinanceApp.Components.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Components.Services;

public class NoteService
{
    private readonly AppDbContext _context;

    public NoteService(AppDbContext context)
    {
        _context = context;
        _context.Database.EnsureCreated();
    }

    public async Task<List<Note>> GetNotesAsync()
    {
        return await _context.Notes.ToListAsync();
    }

    public async Task AddNoteAsync(Note note)
    {
        _context.Notes.Add(note);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteNoteAsync(uint id)
    {
        var note = await _context.Notes.FindAsync(id);
        if (note != null)
        {
            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
        }
    }
}
