using System.ComponentModel.DataAnnotations;

namespace CoreFitness.Domain.Entities
{
    public class Membership
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Typ krävs.")]
        public string Type { get; set; } = string.Empty;

        [Required(ErrorMessage = "Pris krävs.")]
        [Range(1, 9999, ErrorMessage = "Pris måste vara mellan 1 och 9999.")]
        public decimal Price { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Koppling till användaren via UserId (string)
        public string UserId { get; set; } = string.Empty;

        // Bokningar kopplade till medlemskapet (valfritt)
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
