using E_Commerce.Domain.Common;
using E_Commerce.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace E_Commerce.Application.Specifications
{
    public class BaseSpecifications<TEntity, Tkey> : ISpecification<TEntity, Tkey>
    where TEntity : BaseEntity<Tkey>
    {
        public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; private set; } = [];

        public Expression<Func<TEntity, bool>>? Criteria { get; private set;  }

       

        public BaseSpecifications(Expression<Func<TEntity, bool>>? criteria = null)
        {
            Criteria = criteria;
        }

        public void AddInclude(Expression<Func<TEntity, object>> includeExpression)
        {
            IncludeExpressions.Add(includeExpression);
        }

        public Expression<Func<TEntity, object>>? OrderBy { get; private set; }

        public void AddOrderBy(Expression<Func<TEntity, object>>? orderBy)
        {
            OrderBy = orderBy;
        }
        public Expression<Func<TEntity, object>>? OrderByDesc { get; private set; }
        public void AddOrderByDesc(Expression<Func<TEntity, object>>? orderByDesc)
        {
            OrderByDesc = orderByDesc;
        }
    }
}
