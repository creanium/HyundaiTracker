using HyundaiTracker.Core.VehicleAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HyundaiTracker.Infrastructure.Data.Config;

public class VehicleConfiguration : BaseEntityConfiguration<Vehicle>
{
    protected override void Configure(EntityTypeBuilder<Vehicle> builder)
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
        
        builder.Property(e => e.Status)
            .HasConversion(
                s => s.Value,
                s => VehicleStatus.FromValue(s));
    }
}
