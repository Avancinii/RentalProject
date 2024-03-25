namespace MotorcycleRentalSystem.Models
{
    public class MotorCycleModel
    {
        public int Id { get; set; }
        public required int year { get; set; }
        public required string model { get; set; }
        public required string plate { get; set; }

        public ICollection<LocationModel> Location { get; set; }
    }
}
