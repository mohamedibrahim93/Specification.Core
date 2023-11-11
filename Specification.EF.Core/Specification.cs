using System.Linq.Expressions;

namespace Specification.EF.Core;

public abstract class Specification<TEntity> : Specification.Core.Specification<TEntity>, ISpecification<TEntity> where TEntity : class
{
    protected Specification(Expression<Func<TEntity, bool>> expression)
        : base(expression)
    {
    }
}