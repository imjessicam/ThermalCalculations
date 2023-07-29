using Microsoft.EntityFrameworkCore;
using SqlDataAccess.Mapping;
using SqlDataAccess.Models;

namespace SqlDataAccess.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("data");

            modelBuilder.ApplyConfiguration(new CityConfiguartion());
            modelBuilder.ApplyConfiguration(new ExternalDataConfiguration());
            modelBuilder.ApplyConfiguration(new InternalDataConfiguration());
            modelBuilder.ApplyConfiguration(new MonthConfiguration());
            modelBuilder.ApplyConfiguration(new MonthInternalDataConfiguration());
            modelBuilder.ApplyConfiguration(new MonthExternalDataConfiguration())
                ;
            base.OnModelCreating(modelBuilder); 
        }

        public virtual DbSet<City> Cities { get; set; }

        public virtual DbSet<ExternalData> ExternalDatas { get; set; }

        public virtual DbSet<InternalData> InternalDatas { get; set; }

        public virtual DbSet<Month> Months { get; set; }

        public virtual DbSet<MonthExternalData> MonthExternalDatas { get; set; }

        public virtual DbSet<MonthInternalData> MonthInternalDatas { get; set; }
    }
}
