using Microsoft.EntityFrameworkCore;
using MotorcycleRentalSystem.Data.Map;
using MotorcycleRentalSystem.Models;

namespace MotorcycleRentalSystem.Data
{
    public class MotorcycleRentalDBContext : DbContext
    {
        public DbSet<UserModel> User { get; set; }
        public DbSet<MotorCycleModel> MotorCycle { get; set; }
        public DbSet<LocationModel> Location { get; set; }
        public DbSet<PlanModel> Plan { get; set; }
        public MotorcycleRentalDBContext(DbContextOptions<MotorcycleRentalDBContext> options) 
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new MotorCycleMap());
            modelBuilder.ApplyConfiguration(new LocationMap());
            modelBuilder.ApplyConfiguration(new PlanMap());


            base.OnModelCreating(modelBuilder);
        }
    }
}
