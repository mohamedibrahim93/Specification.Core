namespace Specification.Core.Specifications;

internal class NotSpecification<TEntity> : Specification<TEntity> where TEntity : class
{
    public NotSpecification(ISpecification<TEntity> left)
        : base(left.Predicate.Not())
    {
    }
}