using System.Data.Entity;
using KMA.APZRPMJ2018.NumberConverter.DBAdapter.Migrations;
using KMA.APZRPMJ2018.NumberConverter.DBModels;

namespace KMA.APZRPMJ2018.NumberConverter.DBAdapter
{
    internal class ConversionDBContext : DbContext
    {
        public ConversionDBContext() : base("NewConversionDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ConversionDBContext, Configuration>(true));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Conversion> Conversions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new User.UserEntityConfiguration());
            modelBuilder.Configurations.Add(new Conversion.ConversionEntityConfiguration());
        }
    }
}
