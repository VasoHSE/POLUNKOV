using System;
using System.Collections.Generic;

namespace DB_Logic.DB_Repository
{
    public interface IRepository<TEntity>  where TEntity : class
    {
        TEntity Get(int index);
        IEnumerable<TEntity> GetAll();         
        void Add(TEntity data);         
        void Delete(int index);
        void Update(TEntity data);
    }
}
