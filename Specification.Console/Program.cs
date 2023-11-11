using Specification.Console;
using Specification.Console.Entities;
using Specification.Console.Specifications;
using Specification.Core;

Console.WriteLine("get order 1");
var order1 = Context.Orders.Where(new GetByIdSpecification(1).Predicate).FirstOrDefault();
Console.WriteLine(order1);

Console.WriteLine("get order 2");
var order2 = Context.Orders.Query(new GetByIdSpecification(2)).FirstOrDefault();
Console.WriteLine(order2);

Console.WriteLine("get today orders");
var orders3 = Context.Orders.Query(new TodaySpecification()).ToList();
Console.WriteLine(string.Join("\n", orders3));

Console.WriteLine("get order 3");
var predicate1 = PredicateBuilder.Create<OrderEntity>(order => order.Id == 3);
var order3 = Context.Orders.Where(predicate1).FirstOrDefault();
Console.WriteLine(order3);

Console.WriteLine("get orders by filters - 1");
var filters = new { Status = (int?)2, Date = (DateTime?)DateTime.Today };
var query = Context.Orders;
if (filters.Status.HasValue)
    query = query.Status(filters.Status.Value);
if (filters.Date.HasValue)
    query = query.DateEqual(filters.Date.Value);
var filteredOrders1 = query.ToList();
Console.WriteLine(string.Join("\n", filteredOrders1));

Console.WriteLine("get orders by filters - 2");
var predicate2 = PredicateBuilder.True<OrderEntity>();
if (filters.Status.HasValue)
    predicate2 = predicate2.And(c => c.Status == filters.Status);
if (filters.Date.HasValue)
    predicate2 = predicate2.And(c => c.CreationDate.Date == filters.Date.Value.Date);
var filteredOrders2 = Context.Orders.Where(predicate2).ToList();
Console.WriteLine(string.Join("\n", filteredOrders2));

Console.WriteLine("get combine orders");
var query4 = Context.Orders
    .Today()
    .Status(1)
    .MoreThan(1000);
var filteredOrders3 = query4.ToList();
Console.WriteLine(string.Join("\n", filteredOrders3));

Console.WriteLine("get combine and filter orders");
var specification1 = SpecificationBuilder.Create<OrderEntity>();
if (filters.Status.HasValue)
    specification1 = specification1.And(new StatusSpecification(filters.Status.Value));
if (filters.Date.HasValue)
    specification1 = specification1.And(new DateEqualSpecification(filters.Date.Value));
var filteredOrders4 = Context.Orders.Query(specification1);
Console.WriteLine(string.Join("\n", filteredOrders4));

Console.WriteLine("get combine specifications orders");
var specification2 = SpecificationBuilder
    .Create<OrderEntity>()
    .And(new StatusSpecification(filters.Status.Value))
    .And(new DateEqualSpecification(filters.Date.Value));
var filteredOrders5 = Context.Orders.Query(specification2);
Console.WriteLine(string.Join("\n", filteredOrders5));

Console.WriteLine("get combine and filter orders - 2");
var specification3 = SpecificationBuilder.Create<OrderEntity>();
if (filters.Status.HasValue)
    specification3 = specification3.Status(filters.Status.Value);
if (filters.Date.HasValue)
    specification3 = specification1.DateEqual(filters.Date.Value);
var filteredOrders6 = Context.Orders.Query(specification3);
Console.WriteLine(string.Join("\n", filteredOrders6));

Console.WriteLine("get combine specifications orders - 3");
var specification4 = SpecificationBuilder
    .Create<OrderEntity>()
    .Today()
    .Status(2)
    .MoreThan(1000);
var filteredOrders7 = Context.Orders.Query(specification4);
Console.WriteLine(string.Join("\n", filteredOrders7));

Console.WriteLine("get combine specifications orders - multiple status");
var specification5 = SpecificationBuilder
    .Create<OrderEntity>()
    .And(new StatusSpecification(1).Or(new StatusSpecification(2)));
var filteredOrders8 = Context.Orders.Query(specification5);
Console.WriteLine(string.Join("\n", filteredOrders8));

Console.WriteLine("get combine specifications orders - multiple status - 2");
var specification6 = SpecificationBuilder
    .Create<OrderEntity>()
    .Status(4, 3);
var filteredOrders9 = Context.Orders.Query(specification6);
Console.WriteLine(string.Join("\n", filteredOrders9));