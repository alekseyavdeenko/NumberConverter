using System.Data.Entity.Migrations;
namespace KMA.APZRPMJ2018.NumberConverter.DBAdapter.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ConversionDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        protected override void Seed(ConversionDBContext context)
        {
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}