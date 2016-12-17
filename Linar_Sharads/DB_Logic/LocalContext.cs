using DB_Logic.Entities;
using System.Data.Entity;

namespace DB_Logic
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
