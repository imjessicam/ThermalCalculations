using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SqlDataAccess.Models;

namespace SqlDataAccess.Mapping
{
    public class CityConfiguartion : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ExternalId).IsRequired();

            builder.Property(x => x.Name).IsRequired();

            builder.HasMany(x => x.Months)
                .WithOne(x => x.City)
                .HasForeignKey(x => x.CityId);
        }
    }
}
