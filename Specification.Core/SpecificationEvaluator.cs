using Specification.Core.Exceptions;

namespace Specification.Core;

public static class SpecificationEvaluator
{
    public static IQueryable<TEntity> Where<TEntity>(
         this IQueryable<TEntity> inputQueryable,
         ISpecification<TEntity> specification)
         where TEntity : class
    {
        return inputQueryable.Where(specification.Predicate);
    }

    public static IQueryable<TEntity> OrderBy<TEntity>(
        this IQueryable<TEntity> inputQueryable,
        ISpecification<TEntity> specification)
        where TEntity : class
    {
        return inputQueryable.OrderBy(specification.OrderByExpression ??
                                      throw new InvalidSpecificationException("order by expression cannot be null"));
    }

    public static IQueryable<TEntity> OrderByDescending<TEntity>(
        this IQueryable<TEntity> inputQueryable,
        ISpecification<TEntity> specification)
        where TEntity : class
    {
        return inputQueryable.OrderByDescending(specification.OrderByDescendingExpression ??
                                                throw new InvalidSpecificationException("order by descending expression cannot be null"));
    }

    public static IQueryable<TEntity> Query<TEntity>(
        this IQueryable<TEntity> inputQueryable,
        ISpecification<TEntity> specification)
        where TEntity : class
    {
        var queryable = inputQueryable.Where(specification.Predicate);

        if (specification.OrderByExpression is not null)
        {
            queryable = queryable.OrderBy(specification.OrderByExpression);
        }
        else if (specification.OrderByDescendingExpression is not null)
        {
            queryable = queryable.OrderByDescending(specification.OrderByDescendingExpression);
        }

        return queryable;
    }
}