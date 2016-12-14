using DB_Logic.Entities;
using System.Data.Entity;

namespace DB_Logic
{
    internal class AzureContext : DbContext
    {
        public AzureContext() : base("azuresql") { }

        public DbSet<Result> Results { get; set; }

        protected virtual void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Configuration.AutoDetectChangesEnabled = false;
        }
    }
}
