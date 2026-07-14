using E_Commerce.Domain.Common;
using E_Commerce.Domain.Contracts;
using E_Commerce.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Infrastructure.Repositories
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly StoreDbContext _context;

        public GenericRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(TEntity entity, CancellationToken ct = default)
        => await _context.AddAsync(entity, ct);

        public void Delete(TEntity entity)
        => _context.Remove(entity);

        public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken ct = default)
        => await _context.Set<TEntity>().AsNoTracking().ToListAsync(ct);

        public async Task<IReadOnlyList<TEntity>> GetAllWithSpecificationAsync(ISpecification<TEntity, TKey> specification, CancellationToken ct = default)
        {
            var result = SpecificationEvaluator.CreateQuery(_context.Set<TEntity>(), specification);
            return await result.AsNoTracking().ToListAsync(ct);
        }

        public async Task<TEntity?> GetByIdAsync(TKey id, CancellationToken ct = default)
        => await _context.Set<TEntity>().FindAsync(id, ct);

        public async Task<TEntity?> GetByIdWithSpecificationsAsync(ISpecification<TEntity, TKey> specification, CancellationToken ct = default)
        {
            var Result = SpecificationEvaluator.CreateQuery(_context.Set<TEntity>(), specification);
            return await Result.FirstOrDefaultAsync(ct);
        }

        public async Task<int> GetProductCountWithSpecificationsAsync(ISpecification<TEntity, TKey> specification, CancellationToken ct = default)
        {
            var Result = SpecificationEvaluator.CreateQuery(_context.Set<TEntity>(), specification);
            return await Result.CountAsync(ct);
        }

        public void Update(TEntity entity)
        => _context.Update(entity);
    }
}
