using System.ComponentModel.DataAnnotations;

namespace CoreFitness.Domain.Entities
{
    public class GymClass
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Namn krävs.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Kapacitet krävs.")]
        [Range(1, 50, ErrorMessage = "Kapacitet måste vara mellan 1 och 50.")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "Datum krävs.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Tid krävs.")]
        public TimeSpan Time { get; set; }

        // Instruktör (om du använder TeacherId)
        public int? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }

        // Bokningar
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
