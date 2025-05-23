using Microsoft.EntityFrameworkCore;
using vmp_cinema.Data;


public class FilmService : IFilmService
{
    private readonly ApplicationDbContext _context;

    public FilmService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Film>> GetAllAsync(string? search = null)
    {
        var query = _context.Films.AsQueryable();
        if (!string.IsNullOrEmpty(search))
            query = query.Where(f => f.Title.Contains(search));

        return await query.ToListAsync();
    }

    public Task<Film?> GetByIdAsync(int id) => _context.Films.FindAsync(id).AsTask();

    public async Task AddAsync(Film film)
    {
        _context.Films.Add(film);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Film film)
    {
        _context.Films.Update(film);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var film = await _context.Films.FindAsync(id);
        if (film != null)
        {
            _context.Films.Remove(film);
            await _context.SaveChangesAsync();
        }
    }
}
