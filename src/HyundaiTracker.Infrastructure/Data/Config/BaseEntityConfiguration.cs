using Ardalis.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StrictId;
using StrictId.EFCore;

namespace HyundaiTracker.Infrastructure.Data.Config;

public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : EntityBase<Id<T>>
{
    void IEntityTypeConfiguration<T>.Configure(EntityTypeBuilder<T> builder)
    {
        // Do all the configuration specific to `BaseEntity`
        builder.Property(v => v.Id)
            .ValueGeneratedOnAdd()
            .HasStrictIdValueGenerator();

        Configure(builder);
    }

    protected abstract void Configure(EntityTypeBuilder<T> builder);
}
