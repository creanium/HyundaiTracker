using HyundaiTracker.Core.VehicleAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HyundaiTracker.Infrastructure.Data.Config;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.HasIndex(v => v.Vin).IsUnique();

        builder.Property(v => v.Vin)
            .HasMaxLength(17)
            .IsRequired();

        builder.Property(v => v.Year)
            .HasMaxLength(4);

        builder.Property(v => v.Make)
            .HasMaxLength(DataSchemaConstants.DefaultNameLength);

        builder.Property(v => v.Model)
            .HasMaxLength(DataSchemaConstants.DefaultNameLength);
    }
}
