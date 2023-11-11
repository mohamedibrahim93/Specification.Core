using Specification.Console.Entities;
using Specification.Core;

namespace Specification.Console.Specifications;

internal static class DateEqualSpecificationExtension
{
    public static bool DateEqual(this OrderEntity order, DateTime dateTime)
    {
        var specification = new DateEqualSpecification(dateTime);
        return specification.IsSatisfied(order);
    }

    public static IEnumerable<OrderEntity> DateEqual(this IEnumerable<OrderEntity> orders, DateTime dateTime)
    {
        return orders.Where(x => x.DateEqual(dateTime));
    }

    public static IQueryable<OrderEntity> DateEqual(this IQueryable<OrderEntity> orders, DateTime dateTime)
    {
        return orders.Query(new DateEqualSpecification(dateTime));
    }

    public static ISpecification<OrderEntity> DateEqual(this ISpecification<OrderEntity> specification, DateTime dateTime)
    {
        return specification.And(new DateEqualSpecification(dateTime));
    }
}