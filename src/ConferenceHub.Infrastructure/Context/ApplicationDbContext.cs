using ConferenceHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ConferenceHub.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Conference> Conference { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Registration> Registration { get; set; }
        public DbSet<Area> Area { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder =>
            {
                builder.Property(x => x.Email)
                       .HasMaxLength(200)
                       .IsRequired();

                builder.HasIndex(x => x.Email)
                       .IsUnique();
            });
        }

    }
}
