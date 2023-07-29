
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SqlDataAccess.Models;

namespace SqlDataAccess.Mapping
{
    public class ExternalDataConfiguration : IEntityTypeConfiguration<ExternalData>
    {
        public void Configure(EntityTypeBuilder<ExternalData> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ExternalId).IsRequired();

            builder.Property(x => x.Temperature)
                .IsRequired()
                .HasPrecision(10);

            builder.Property(x => x.Humidity)
                .IsRequired()
                .HasPrecision(10);

            builder.HasMany(x => x.MonthExternalDatas)
                .WithOne(x => x.ExternalData)
                .HasForeignKey(x => x.ExternalDataId);
        }
    }
}
