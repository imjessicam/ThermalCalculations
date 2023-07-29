
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SqlDataAccess.Models;

namespace SqlDataAccess.Mapping
{
    public class MonthInternalDataConfiguration : IEntityTypeConfiguration<MonthInternalData>
    {
        public void Configure(EntityTypeBuilder<MonthInternalData> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ExternalId).IsRequired();
        }
    }
}
