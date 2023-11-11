using System.Linq.Expressions;

namespace Specification.Core;

public interface ISpecificationFactory
{
    ISpecification<TEntity> Create<TEntity>()
        where TEntity : class;

    ISpecification<TEntity> Create<TEntity>(
        Expression<Func<TEntity, bool>> expression)
        where TEntity : class;
}