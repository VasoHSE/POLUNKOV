namespace DB_Logic.Migrations.Azure
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class AzureConfiguration : DbMigrationsConfiguration<DB_Logic.AzureContext>
    {
        public AzureConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DB_Logic.AzureContext context)
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
