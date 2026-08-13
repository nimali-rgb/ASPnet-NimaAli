using Microsoft.AspNetCore.Identity;

namespace CoreFitness.Web.Areas.Identity.Data;

public class ApplicationUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
    public string? ProfileImageUrl { get; set; }
}
