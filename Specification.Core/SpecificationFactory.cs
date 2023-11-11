using Specification.Core.Specifications;
using System.Linq.Expressions;

namespace Specification.Core;

public class SpecificationFactory : ISpecificationFactory
{
    public ISpecification<TEntity> Create<TEntity>() where TEntity : class
    {
        return new EmptySpecification<TEntity>();
    }

    public ISpecification<TEntity> Create<TEntity>(
        Expression<Func<TEntity, bool>> expression)
        where TEntity : class
    {
        return new ExpressionSpecification<TEntity>(expression);
    }
}