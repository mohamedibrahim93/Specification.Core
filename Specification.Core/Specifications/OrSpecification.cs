namespace Specification.Core.Specifications;

internal class OrSpecification<TEntity> : Specification<TEntity> where TEntity : class
{
    public OrSpecification(ISpecification<TEntity> left, ISpecification<TEntity> right)
        : base(left.Predicate.Or(right.Predicate))
    {
    }
}