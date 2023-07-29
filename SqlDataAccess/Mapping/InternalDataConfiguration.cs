using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SqlDataAccess.Models;

namespace SqlDataAccess.Mapping
{
    public class InternalDataConfiguration : IEntityTypeConfiguration<InternalData>
    {
        public void Configure(EntityTypeBuilder<InternalData> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ExternalId).IsRequired();

            builder.Property(x => x.Temperature)
                .IsRequired()
                .HasPrecision(10);

            builder.Property(x => x.Humidity)
                .IsRequired()
                .HasPrecision(10);

            builder.HasMany(x => x.MonthInternalDatas)
                .WithOne(x => x.InternalData)
                .HasForeignKey(x => x.InternalDataId);
        }
    }
}
