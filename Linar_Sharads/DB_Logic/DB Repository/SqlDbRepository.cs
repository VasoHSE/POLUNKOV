using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DB_Logic.DB_Repository
{
    public class SqlDbRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;

        public SqlDbRepository(DbContext context)
        {
            this._context = context;
        }

        public TEntity Get(int index)
        {
            return _context.Set<TEntity>().Find(index);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public void Update(TEntity data)
        {
            _context.Entry(data).State = EntityState.Modified;
        }

        public void Add(TEntity data)
        {
            _context.Set<TEntity>().Add(data);
        }

        public void Delete(int index)
        {
            var lg = _context.Set<TEntity>().Find(index);
            if (lg != null)
                _context.Set<TEntity>().Remove(lg);
        }
    }
}
