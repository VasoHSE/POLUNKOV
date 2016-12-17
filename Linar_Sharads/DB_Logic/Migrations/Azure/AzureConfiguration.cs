using System.Data.Entity.Migrations;

namespace DB_Logic.Migrations.Azure
{
    internal sealed class AzureConfiguration : DbMigrationsConfiguration<DB_Logic.Context.AzureContext>
    {
        public AzureConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DB_Logic.Context.AzureContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
