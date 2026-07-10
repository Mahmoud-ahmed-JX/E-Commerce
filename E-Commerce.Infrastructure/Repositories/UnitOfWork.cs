using E_Commerce.Domain.Common;
using E_Commerce.Domain.Contracts;
using E_Commerce.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Infrastructure.Repositories
{
    public class UnitOfWork(StoreDbContext _dbContext) : IUnitOfWork
    {
        private readonly Dictionary<string, object> _repos = [];
        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            var typename = typeof(TEntity).Name;
            if(_repos.TryGetValue(typename,out object oldRepo))
                return (IGenericRepository<TEntity, TKey>)oldRepo;
            var newRepo = new GenericRepository<TEntity, TKey>(_dbContext);
            _repos.Add(typename, newRepo);
            return newRepo;
        }

        public async Task SaveChangesAsync(CancellationToken ct = default)
        => await _dbContext.SaveChangesAsync(ct);
    }
}
