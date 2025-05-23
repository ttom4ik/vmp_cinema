using Microsoft.EntityFrameworkCore;
using vmp_cinema.Data;

public class SeanceService : ISeanceService
{
    private readonly ApplicationDbContext _context;

    public SeanceService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Seance>> GetAllAsync()
    {
        return await _context.Seances.Include(s => s.Film).ToListAsync();
    }

    public async Task<Seance?> GetByIdAsync(int id)
    {
        return await _context.Seances
            .Include(s => s.Film)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task AddAsync(Seance seance)
    {
        _context.Seances.Add(seance);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Seance seance)
    {
        _context.Seances.Update(seance);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var seance = await _context.Seances.FindAsync(id);
        if (seance != null)
        {
            _context.Seances.Remove(seance);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Seances.AnyAsync(e => e.Id == id);
    }
}
