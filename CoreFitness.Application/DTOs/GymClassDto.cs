namespace CoreFitness.Application.DTOs;

public class GymClassDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
    public string? Instructor { get; set; }
    public string? Category { get; set; }
}