using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotorcycleRentalSystem.Models;

namespace MotorcycleRentalSystem.Data.Map
{
    public class UserMap : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.name)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(x => x.CNPJ)
                .IsRequired()
                .HasMaxLength(14);
            builder.Property(x => x.birthDate)
                .IsRequired();
            builder.Property(x => x.cnhNumber)
                .IsRequired();
            builder.Property(x => x.cnhType)
                .IsRequired();
            builder.Property(x => x.cnhImagePath)
                .IsRequired()
                .HasMaxLength(1000);
            builder.Property(u => u.profileId)
                .IsRequired();
        }
    }
}
