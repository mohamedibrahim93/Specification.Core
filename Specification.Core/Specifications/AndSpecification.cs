namespace Specification.Core.Specifications;

internal class AndSpecification<TEntity> : Specification<TEntity> where TEntity : class
{
    public AndSpecification(ISpecification<TEntity> left, ISpecification<TEntity> right)
        : base(left.Predicate.And(right.Predicate))
    {
    }
}