using E_Commerce.Domain.Common;
using E_Commerce.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Infrastructure.Repositories
{
    public class SpecificationEvaluator
    {
        public static IQueryable<TEntity> CreateQuery<TEntity,Tkey>(IQueryable<TEntity> inpuQuery, ISpecification<TEntity,Tkey> specification ) where TEntity : BaseEntity<Tkey>
        {
            var query = inpuQuery;
            if(specification.IncludeExpressions.Count > 0)
            {
                query = specification.IncludeExpressions.Aggregate(query,(current,expression) => current.Include(expression));
            }
            if(specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }
            if(specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }
            if(specification.OrderByDesc != null)
            {
                query = query.OrderByDescending(specification.OrderByDesc);
            }
            return query;
        }
    }
}
