using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotorcycleRentalSystem.Models;

namespace MotorcycleRentalSystem.Data.Map
{
    public class LocationMap : IEntityTypeConfiguration<LocationModel>
    {
        public void Configure(EntityTypeBuilder<LocationModel> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(x => x.locationType).IsRequired();
            builder.Property(x => x.creationDate).IsRequired();
            builder.Property(x => x.startDate).IsRequired();
            builder.Property(x => x.endDate).IsRequired();
            builder.Property(x => x.expectedEndDate).IsRequired();
            builder.Property(x => x.totalLocationValue).IsRequired();
            builder.Property(x => x.isActive).IsRequired();

            builder.Property(x => x.userId).IsRequired();
            builder.Property(x => x.motorCycleId).IsRequired();
            builder.Property(x => x.planId).IsRequired();


            builder.HasOne(x => x.User)
                .WithMany(l => l.Location)
                .HasForeignKey(x => x.userId);

            builder.HasOne(m => m.MotorCycle)
                .WithMany(l => l.Location)
                .HasForeignKey(x => x.motorCycleId);

            builder.HasOne(p => p.Plan)
                .WithMany(l => l.Location)
                .HasForeignKey(x => x.planId);
        }
    }
}
