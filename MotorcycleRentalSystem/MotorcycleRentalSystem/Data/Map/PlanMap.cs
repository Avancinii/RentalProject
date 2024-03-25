using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotorcycleRentalSystem.Models;

namespace MotorcycleRentalSystem.Data.Map
{
    public class PlanMap : IEntityTypeConfiguration<PlanModel>
    {
        public void Configure(EntityTypeBuilder<PlanModel> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(x => x.periodValue).IsRequired();
            builder.Property(x => x.periodType).IsRequired();
            builder.Property(x => x.ticketValue).IsRequired();
        }
    }
}
