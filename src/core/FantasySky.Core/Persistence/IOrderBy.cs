using System.Collections;
using System.Linq.Expressions;

namespace FantasySky.Core.Persistence;

public interface IOrderBy<T> : IEnumerable<OrderByDescriptor<T>>
{
    ICollection<OrderByDescriptor<T>> Sorts { get; }
}

public class OrderByDescriptor<T>
{
    public OrderByDescriptor(
        SortDirection sortDirection,
        Expression<Func<T, object>> expression)
    {
        this.SortDirection = sortDirection;
        this.OrderByExpression = expression;
    }

    public SortDirection SortDirection { get; }
    public Expression<Func<T, object>> OrderByExpression { get; }
}

public class OrderBy<T> : IOrderBy<T>
{
    public OrderBy() { }

    public OrderBy(SortDirection sortDirection, Expression<Func<T, object>> expression)
    {
        this.Sorts.Add(new(sortDirection, expression));
    }

    public ICollection<OrderByDescriptor<T>> Sorts { get; } = new List<OrderByDescriptor<T>>(1);

    public IEnumerator<OrderByDescriptor<T>> GetEnumerator() => this.Sorts.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}

public static class SortsExtensions
{
    public static OrderBy<T> OrderBy<T>(Expression<Func<T, object>> expression) => new(SortDirection.Ascending, expression);
    public static OrderBy<T> OrderByDescending<T>(Expression<Func<T, object>> expression) => new(SortDirection.Descending, expression);
    public static OrderBy<T> OrderBy<T>(this OrderBy<T> orderBy, Expression<Func<T, object>> expression)
    {
        orderBy.Sorts.Add(new(SortDirection.Ascending, expression));
        return orderBy;
    }
    public static OrderBy<T> OrderByDescending<T>(this OrderBy<T> orderBy, Expression<Func<T, object>> expression)
    {
        orderBy.Sorts.Add(new(SortDirection.Descending, expression));
        return orderBy;
    }
}
