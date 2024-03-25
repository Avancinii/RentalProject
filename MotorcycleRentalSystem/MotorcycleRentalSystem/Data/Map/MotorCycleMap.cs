using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotorcycleRentalSystem.Models;

namespace MotorcycleRentalSystem.Data.Map
{
    public class MotorCycleMap : IEntityTypeConfiguration<MotorCycleModel>
    {
        public void Configure(EntityTypeBuilder<MotorCycleModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.year).IsRequired();
            builder.Property(x => x.model).IsRequired();
            builder.Property(x => x.plate).IsRequired();
        }        
    }
}
