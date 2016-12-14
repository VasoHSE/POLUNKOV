using DB_Logic.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DB_Logic.Repository
{
    class AzuresqlRepository : IRepository<Result>
    {
        private AzureContext context;
        private bool disposed = false;

        public AzuresqlRepository()
        {
            context = new AzureContext();
        }

        public Result Get(int index)
        {
            return context.Results.Find(index);
        }

        public IEnumerable<Result> GetAll()
        {
            return context.Results;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Result data)
        {
            context.Entry(data).State = EntityState.Modified;
        }

        public void Add(Result data)
        {
            context.Results.Add(data);
        }

        public void Delete(int index)
        {
            var lg = context.Results.Find(index);
            if (lg != null)
                context.Results.Remove(lg);
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
