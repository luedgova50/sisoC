namespace sisoC.Migrations
{
    
    using System.Data.Entity.Migrations;
    using sisoC.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SisoCdataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;

            AutomaticMigrationDataLossAllowed = true;

            ContextKey = "sisoC.Models.SisoCdataContext";
        }

        protected override void Seed(sisoC.Models.SisoCdataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
