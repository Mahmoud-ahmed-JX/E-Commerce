using E_Commerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace E_Commerce.Domain.Contracts
{
    public interface ISpecification<TEntity,Tkey> where TEntity : BaseEntity<Tkey>
    {
        List<Expression<Func<TEntity,object>>> IncludeExpressions { get; }
        Expression<Func<TEntity, bool>>? Criteria { get; }
        Expression<Func<TEntity, object>>? OrderBy { get; }
        Expression<Func<TEntity, object>>? OrderByDesc { get; }
        int Skip { get; }
        int Take { get; }
        bool IsPaginated { get; }

    }
}
