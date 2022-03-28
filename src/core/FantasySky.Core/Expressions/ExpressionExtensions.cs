using System.Linq.Expressions;

namespace FantasySky.Core.Expressions;

public static class ExpressionExtensions
{
    //public static Expression<>

    public static Expression<Func<T, bool>> And<T>(
        this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
    {
        //left.Parameters
        //    .Select((f, i) => new { f, s = right.Parameters[i] })
        //    .ToDictionary(m => m.s, m => m.f);

        //var body = ExpressionVisitor.Visit(left);

        //return Expression.Lambda(Expression.AndAlso(left.Body, body), left.Parameters);

        throw new NotImplementedException();
    }
}
