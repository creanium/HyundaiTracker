using HyundaiTracker.Core.VehicleAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HyundaiTracker.Infrastructure.Data.Config;

public class TrackingEventConfiguration : IEntityTypeConfiguration<TrackingEvent>
{
    public void Configure(EntityTypeBuilder<TrackingEvent> builder)
    {
        builder.HasIndex(e => e.Occurred);

        builder.Property(e => e.Occurred)
            .IsRequired();

        builder.Property(e => e.Status)
            .IsRequired()
            .HasConversion(
                s => s.Value,
                s => VehicleStatus.FromValue(s));
    }
}
