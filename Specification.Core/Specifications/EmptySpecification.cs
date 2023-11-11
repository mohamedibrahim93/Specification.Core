namespace Specification.Core.Specifications;

internal class EmptySpecification<TEntity> : Specification<TEntity> where TEntity : class
{
    public EmptySpecification()
        : base(PredicateBuilder.True<TEntity>())
    {
    }
}