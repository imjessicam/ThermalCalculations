
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SqlDataAccess.Models;

namespace SqlDataAccess.Mapping
{
    public class MonthConfiguration : IEntityTypeConfiguration<Month>
    {
        public void Configure(EntityTypeBuilder<Month> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ExternalId).IsRequired();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasConversion<int>();

            builder.HasMany(x => x.MonthExternalDatas)
                .WithOne(x => x.Month)
                .HasForeignKey(x => x.MonthId);

            builder.HasMany(x => x.MonthInternalDatas)
                .WithOne(x => x.Month)
                .HasForeignKey(x => x.MonthId);
        }
    }
}
