namespace Specification.EF.Core;

public interface ISpecification<TEntity> : Specification.Core.ISpecification<TEntity>
    where TEntity : class
{
    bool IsSplitQuery { get; }
    bool IsNoTracking { get; }
}