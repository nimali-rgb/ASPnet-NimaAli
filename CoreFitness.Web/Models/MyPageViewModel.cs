using CoreFitness.Domain.Entities;

namespace CoreFitness.Web.Models
{
    public class MyPageViewModel
    {
        // Membership
        public Membership? Membership { get; set; }
        public bool HasMembership => Membership != null;

        // Bookings
        public List<Booking> Bookings { get; set; } = new();

        // Profile info
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        // Member since (optional)
        public DateTime? MemberSince { get; set; }

        // Profile image
        public string ProfileImageUrl { get; set; } = "/images/default-profile.png";
    }
}
