namespace CoreFitness.Application.DTOs;

public class BookingCreateDto
{
    public string UserId { get; set; } = string.Empty;
    public int GymClassId { get; set; }
}