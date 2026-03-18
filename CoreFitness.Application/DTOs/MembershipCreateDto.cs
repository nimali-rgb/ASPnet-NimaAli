namespace CoreFitness.Application.DTOs;

public class MembershipCreateDto
{
    public string UserId { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public decimal Price { get; set; }
}