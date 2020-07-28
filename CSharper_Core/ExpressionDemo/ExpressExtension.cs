using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;

namespace ExpressionDemo
{
public static class ExpressExtension
{
    public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second,
        Func<Expression, Expression, Expression> merge)
    {
        if (first == null)
        {
            return second;
        }

        if (second == null)
        {
            return first;
        }

        var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] })
            .ToDictionary(p => p.s, p => p.f);
        var secondBody = ParameterReminder.ReplaceParameters(map, second.Body);
        return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
    }

    public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first,
        Expression<Func<T, bool>> second)
    {
        if (first == null)
        {
            return second;
        }

        return second == null ? first : first.Compose(second, Expression.AndAlso);
    }

}

class ParameterReminder : ExpressionVisitor
{
    private readonly Dictionary<ParameterExpression, ParameterExpression> _map;

    private ParameterReminder(Dictionary<ParameterExpression, ParameterExpression> map)
    {
        _map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
    }

    public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map,
        Expression expr)
    {
        return new ParameterReminder(map).Visit(expr);
    }

    protected override Expression VisitParameter(ParameterExpression node)
    {
        if (_map.TryGetValue(node, out var replacement))
        {
            node = replacement;
        }

        return base.VisitParameter(node);
    }
}
}