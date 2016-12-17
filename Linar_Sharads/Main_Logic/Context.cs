
using Main_Logic.Entities;
using System.Data.Entity;

namespace Main_Logic
{
    public class Context : DbContext
    {
        public Context() : base("localsql") { }

        public DbSet<LineGraph> LineGraph { get; set; }

        protected virtual void OnModelCreating (DbModelBuilder modelBuilder)
        {
            Configuration.AutoDetectChangesEnabled = false;
        }
    }
}
