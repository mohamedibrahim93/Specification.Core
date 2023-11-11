using System.Linq.Expressions;

namespace Specification.Core.Specifications;

internal class ExpressionSpecification<TEntity> : Specification<TEntity> where TEntity : class
{
    public ExpressionSpecification(Expression<Func<TEntity, bool>> predicate)
        : base(predicate)
    {
    }
}