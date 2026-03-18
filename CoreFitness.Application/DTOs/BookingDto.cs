namespace CoreFitness.Application.DTOs;

public class BookingDto
{
    public int Id { get; set; }
    public int GymClassId { get; set; }
    public string GymClassName { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}