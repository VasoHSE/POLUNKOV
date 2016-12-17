using System;
using System.Collections.Generic;

namespace DB_Logic.Repository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        T Get(int index);
        IEnumerable<T> GetAll();         
        void Add(T data);         
        void Delete(int index);
        void Update(T data);
        void Save();  
    }
}
