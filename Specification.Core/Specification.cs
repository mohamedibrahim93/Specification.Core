using Specification.Core.Exceptions;
using System.Linq.Expressions;

namespace Specification.Core;

public abstract class Specification<TEntity> : ISpecification<TEntity> where TEntity : class
{
    public Expression<Func<TEntity, bool>> Predicate { get; }

    protected Specification(Expression<Func<TEntity, bool>> expression) => Predicate = expression;

    public bool IsSatisfied(TEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        if (Predicate == null)
            throw new InvalidSpecificationException("Predicate cannot be null");

        return Predicate.Compile()(entity);
    }

    public List<Expression<Func<TEntity, object>>> IncludeExpression { get; } = new();
    public Expression<Func<TEntity, object>>? OrderByExpression { get; private set; }
    public Expression<Func<TEntity, object>>? OrderByDescendingExpression { get; private set; }

    public bool IsSplitQuery { get; private set; }
    public bool IsNoTracking { get; private set; }

    protected void AddInclude(Expression<Func<TEntity, object>> includeExpression) => IncludeExpression.Add(includeExpression);

    protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression) => OrderByExpression = orderByExpression;

    protected void AddOrderByDescending(Expression<Func<TEntity, object>> orderByDescendingExpression) => OrderByDescendingExpression = orderByDescendingExpression;

    protected void SetSplitQuery(bool splitQuery) => IsSplitQuery = splitQuery;

    protected void SetNoTracking(bool noTracking) => IsNoTracking = noTracking;
}