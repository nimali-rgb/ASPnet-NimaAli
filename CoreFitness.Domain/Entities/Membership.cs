namespace CoreFitness.Domain.Entities;

public class Membership
{
    public int Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string UserId { get; set; } = string.Empty;
    public ApplicationUser User { get; set; } = null!;
}