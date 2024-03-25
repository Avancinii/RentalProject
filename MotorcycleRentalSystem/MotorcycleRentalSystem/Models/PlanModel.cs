namespace MotorcycleRentalSystem.Models
{
    public class PlanModel
    {
        public int Id { get; set; }
        public required double periodValue { get; set; }
        public required string periodType { get; set; }
        public required double ticketValue { get; set; }
        public virtual ICollection<LocationModel> Location { get; set; }
    }
}
