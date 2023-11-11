using System.Linq.Expressions;

namespace Specification.Core;

public interface ISpecification<TEntity>
    where TEntity : class
{
    Expression<Func<TEntity, bool>> Predicate { get; }

    bool IsSatisfied(TEntity entity);

    List<Expression<Func<TEntity, object>>> IncludeExpression { get; }
    Expression<Func<TEntity, object>>? OrderByExpression { get; }
    Expression<Func<TEntity, object>>? OrderByDescendingExpression { get; }
}