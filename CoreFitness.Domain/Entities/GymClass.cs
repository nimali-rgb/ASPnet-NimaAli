namespace CoreFitness.Domain.Entities
{
    public class GymClass
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Capacity { get; set; }

        public DateTime Date { get; set; }    
        public TimeSpan Time { get; set; }     
    }
}
