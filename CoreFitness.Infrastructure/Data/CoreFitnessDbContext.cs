using Microsoft.EntityFrameworkCore;
using CoreFitness.Domain.Entities;

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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // ⭐ MEMBERSHIP → Price precision
            builder.Entity<Membership>()
                .Property(m => m.Price)
                .HasPrecision(18, 2);

            // GYMCLASS → BOOKINGS (1:N)
            builder.Entity<Booking>()
                .HasOne(b => b.GymClass)
                .WithMany(c => c.Bookings)
                .HasForeignKey(b => b.GymClassId)
                .OnDelete(DeleteBehavior.Cascade);

            // TEACHER → GYMCLASSES (1:N)
            builder.Entity<GymClass>()
                .HasOne(c => c.Teacher)
                .WithMany(t => t.Classes)
                .HasForeignKey(c => c.TeacherId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
