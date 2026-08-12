

using CoreFitness.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreFitness.Infrastructure.Data
{
    public class CoreFitnessDbContext : DbContext
    {
        public CoreFitnessDbContext(DbContextOptions<CoreFitnessDbContext> options)
            : base(options)
        {
        }

        public DbSet<Membership> Memberships { get; set; }
        public DbSet<GymClass> GymClasses { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

    }
}
