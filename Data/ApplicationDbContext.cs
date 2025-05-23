using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace vmp_cinema.Data
{
    public class ApplicationDbContext : IdentityDbContext 
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Seance> Seances { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
