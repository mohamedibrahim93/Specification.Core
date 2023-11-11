using System.Linq.Expressions;

namespace Specification.Core;

/// <summary>
/// Enables the efficient, dynamic composition of query predicates.
/// </summary>
public static class PredicateBuilder
{
    /// <summary>
    /// Creates a predicate that evaluates to true.
    /// </summary>
    public static Expression<Func<T, bool>> True<T>() => param => true;

    /// <summary>
    /// Creates a predicate that evaluates to false.
    /// </summary>
    public static Expression<Func<T, bool>> False<T>() => param => false;

    /// <summary>
    /// Creates a predicate expression from the specified lambda expression.
    /// </summary>
    public static Expression<Func<T, bool>> Create<T>(Expression<Func<T, bool>> predicate) => predicate;

    /// <summary>
    /// Combines the left predicate with the right using the logical "and".
    /// </summary>
    public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
    {
        if (left is null)
            throw new ArgumentNullException(nameof(left));

        if (right is null)
            throw new ArgumentNullException(nameof(right));

        var invokedExpr = Expression.Invoke(right, left.Parameters);
        return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(left.Body, invokedExpr), left.Parameters);
    }

    /// <summary>
    /// Combines the left predicate with the right using the logical "or".
    /// </summary>
    public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
    {
        if (left is null)
            throw new ArgumentNullException(nameof(left));

        if (right is null)
            throw new ArgumentNullException(nameof(right));

        var invokedExpr = Expression.Invoke(right, left.Parameters);
        return Expression.Lambda<Func<T, bool>>(Expression.OrElse(left.Body, invokedExpr), left.Parameters);
    }

    /// <summary>
    /// Negates the predicate.
    /// </summary>
    public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> expression)
    {
        var negated = Expression.Not(expression.Body);
        return Expression.Lambda<Func<T, bool>>(negated, expression.Parameters);
    }
}