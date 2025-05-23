using System.Collections.Generic;
using System.Threading.Tasks;

public interface ISeanceService
{
    Task<List<Seance>> GetAllAsync();
    Task<Seance?> GetByIdAsync(int id);
    Task AddAsync(Seance seance);
    Task UpdateAsync(Seance seance);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}
