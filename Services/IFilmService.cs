public interface IFilmService
{
    Task<List<Film>> GetAllAsync(string? search = null);
    Task<Film?> GetByIdAsync(int id);
    Task AddAsync(Film film);
    Task UpdateAsync(Film film);
    Task DeleteAsync(int id);
}
