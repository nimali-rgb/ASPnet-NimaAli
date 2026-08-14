using Microsoft.AspNetCore.Identity;
using CoreFitness.Domain.Entities;

namespace CoreFitness.Web.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        // Extra profilinfo
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? ProfileImageUrl { get; set; }

        // Relation till Membership
        public int? MembershipId { get; set; }
        public Membership? Membership { get; set; }

        // Relation till Bookings
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
