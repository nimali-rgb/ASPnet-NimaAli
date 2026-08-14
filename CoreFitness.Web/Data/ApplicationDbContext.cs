using CoreFitness.Web.Areas.Identity.Data;
using CoreFitness.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoreFitness.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Membership> Memberships { get; set; }
        public DbSet<GymClass> GymClasses { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}
