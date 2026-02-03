using ConferenceHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConferenceHub.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base (options)
        {            
        }

        public DbSet<Conference> Conference { get; set; }
    }
}
