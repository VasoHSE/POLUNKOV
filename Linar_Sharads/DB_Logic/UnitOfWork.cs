using DB_Logic.Context;
using DB_Logic.DB_Entities;
using DB_Logic.DB_Repository;
using System;
using System.Data.Entity;

namespace DB_Logic
{
    public class UnitOfWork : IDisposable
    {
        private readonly DbContext _context;

        public UnitOfWork(string type)
        {
            if (type == "local")
                _context = new LocalContext();
            else if (type == "azure")
                _context = new AzureContext();
        }

        private SqlDbRepository<LineGraph> _localRepository;
        private SqlDbRepository<Result> _remoteRepository;

        public SqlDbRepository<LineGraph> LineGraphs =>
            _localRepository ?? (_localRepository = new SqlDbRepository<LineGraph>(_context));

        public SqlDbRepository<Result> Results =>
            _remoteRepository ?? (_remoteRepository = new SqlDbRepository<Result>(_context));

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed;

        public void Dispose()
        {
            if (!_disposed)
                _context.Dispose();
            _disposed = true;
            GC.SuppressFinalize(this);
        }
    }
}
