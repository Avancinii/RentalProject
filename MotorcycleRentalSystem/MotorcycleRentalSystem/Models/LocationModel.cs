namespace MotorcycleRentalSystem.Models
{
    public class LocationModel
    {
        public int Id { get; set; }
        public string? locationType { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public DateTime expectedEndDate { get; set; }
        public double totalLocationValue { get; set; }
        public bool isActive { get; set; }

        //Relacionamentos
        public int userId { get; set; }
        public required UserModel User { get; set; }
        public int motorCycleId { get; set; }
        public required MotorCycleModel MotorCycle { get; set; }
        public int planId { get; set; }
        public required PlanModel Plan { get; set;}
    }
}
