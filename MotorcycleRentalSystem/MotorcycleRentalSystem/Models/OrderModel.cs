using MotorcycleRentalSystem.Enuns;

namespace MotorcycleRentalSystem.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public double RaceValue { get; set; }
        public Situation Situation { get; set; }
        public int? userId { get; set; }
        public UserModel? User { get; set; }

    }
}
