using System.Data.Entity;
using DB_Logic.DB_Entities;

namespace DB_Logic.Context
{
    internal class LocalContext : DbContext
    {
        public LocalContext() : base("localsql") { }

        public DbSet<LineGraph> LineGraphs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Configuration.AutoDetectChangesEnabled = false;
        }
    }
}
