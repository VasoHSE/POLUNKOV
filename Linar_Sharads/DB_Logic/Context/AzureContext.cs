using System.Data.Entity;
using DB_Logic.DB_Entities;

namespace DB_Logic.Context
{
    internal class AzureContext : DbContext
    {
        public AzureContext() : base("azuresql") { }

        public DbSet<Result> Results { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Configuration.AutoDetectChangesEnabled = false;
        }
    }
}
