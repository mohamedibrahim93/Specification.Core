using Specification.Core.Specifications;
using System.Linq.Expressions;

namespace Specification.Core;

public static class SpecificationExtensions
{
    public static ISpecification<TEntity> And<TEntity>(
        this ISpecification<TEntity> left,
        ISpecification<TEntity> other)
        where TEntity : class
    {
        if (other == null)
            throw new ArgumentNullException(nameof(other));

        return new AndSpecification<TEntity>(left, other);
    }

    public static ISpecification<TEntity> And<TEntity>(
        this ISpecification<TEntity> left,
        Expression<Func<TEntity, bool>> expression)
        where TEntity : class
    {
        if (expression == null)
            throw new ArgumentNullException(nameof(expression));

        return new AndSpecification<TEntity>(left, new ExpressionSpecification<TEntity>(expression));
    }

    public static ISpecification<TEntity> Or<TEntity>(
        this ISpecification<TEntity> left,
        ISpecification<TEntity> other)
        where TEntity : class
    {
        if (other == null)
            throw new ArgumentNullException(nameof(other));

        return new OrSpecification<TEntity>(left, other);
    }

    public static ISpecification<TEntity> Or<TEntity>(
        this ISpecification<TEntity> left,
        Expression<Func<TEntity, bool>> expression)
        where TEntity : class
    {
        if (expression == null)
            throw new ArgumentNullException(nameof(expression));

        return new OrSpecification<TEntity>(left, new ExpressionSpecification<TEntity>(expression));
    }

    public static ISpecification<TEntity> Not<TEntity>(
        this ISpecification<TEntity> left)
        where TEntity : class
    {
        return new NotSpecification<TEntity>(left);
    }
}