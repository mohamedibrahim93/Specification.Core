using Microsoft.EntityFrameworkCore;

namespace Specification.EF.Core;

public static class SpecificationEvaluator
{
    public static IQueryable<TEntity> Query<TEntity>(
        this IQueryable<TEntity> inputQueryable,
        ISpecification<TEntity> specification)
        where TEntity : class
    {
        var queryable = inputQueryable.Where(specification.Predicate);

        if (specification.IncludeExpression.Any())
        {
            queryable = specification.IncludeExpression.Aggregate(
                queryable,
                (current, includeExpression) => current.Include(includeExpression));
        }

        if (specification.OrderByExpression is not null)
        {
            queryable = queryable.OrderBy(specification.OrderByExpression);
        }
        else if (specification.OrderByDescendingExpression is not null)
        {
            queryable = queryable.OrderByDescending(specification.OrderByDescendingExpression);
        }

        if (specification.IsSplitQuery)
        {
            queryable = queryable.AsSplitQuery();
        }

        if (specification.IsNoTracking)
        {
            queryable = queryable.AsNoTracking();
        }

        return queryable;
    }
}