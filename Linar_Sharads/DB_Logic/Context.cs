using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main_Logic.DBO;

namespace Main_Logic
{
    internal class Context : DbContext
    {
        public Context() : base("azuresql") { }

        public DbSet<Area> Areas { get; set; }
        public DbSet<LineGraph> LineGraphs { get; set; }
        public DbSet<Result> Results { get; set; }

        protected virtual void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}
