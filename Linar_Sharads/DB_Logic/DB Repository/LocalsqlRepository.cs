using DB_Logic.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DB_Logic.Repository
{
    public class LocalsqlRepository : IRepository<LineGraph>
    {
        private LocalContext context;
        private bool disposed = false;

        public LocalsqlRepository()
        {
            context = new LocalContext();
        }

        public LineGraph Get(int index)
        {
            return context.LineGraphs.Find(index);
        }

        public IEnumerable<LineGraph> GetAll()
        {
            return context.LineGraphs;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(LineGraph data)
        {
            context.Entry(data).State = EntityState.Modified;
        }

        public void Add(LineGraph data)
        {
            context.LineGraphs.Add(data);
        }

        public void Delete(int index)
        {
            var lg = context.LineGraphs.Find(index);
            if (lg != null)
                context.LineGraphs.Remove(lg);
        }

        public void Dispose()
        {
            if (!disposed)
                context.Dispose();
            disposed = true;
            GC.SuppressFinalize(this);
        }
    }
}
