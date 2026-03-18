namespace CoreFitness.Domain.Entities;

public class Booking
{
    public int Id { get; set; }

    public string UserId { get; set; } = string.Empty;
    public ApplicationUser User { get; set; } = null!;

    public int GymClassId { get; set; }
    public GymClass GymClass { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}