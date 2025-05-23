using System.Collections.Generic;
using System.Threading.Tasks;

public interface IBookingService
{
    Task<List<Booking>> GetAllAsync();
    Task<Booking?> GetByIdAsync(int id);
    Task AddAsync(Booking booking);
    Task UpdateAsync(Booking booking);
    Task DeleteAsync(int id);
}
