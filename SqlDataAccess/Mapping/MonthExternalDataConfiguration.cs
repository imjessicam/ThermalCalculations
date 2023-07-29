using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SqlDataAccess.Models;

namespace SqlDataAccess.Mapping
{
    public class MonthExternalDataConfiguration : IEntityTypeConfiguration<MonthExternalData>
    {
        public void Configure(EntityTypeBuilder<MonthExternalData> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ExternalId).IsRequired();
        }
    }
}
