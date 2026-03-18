using Microsoft.AspNetCore.Identity;

namespace CoreFitness.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
    public string? ProfileImageUrl { get; set; }

    // Navigation properties
    public Membership? Membership { get; set; }
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}