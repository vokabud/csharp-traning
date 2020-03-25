using System;
using System.Linq.Expressions;

namespace ExpressionTreesBuilder
{
    /// <summary>
    /// Expression builder interface.
    /// </summary>
    public static class ExpressionBuilder
    {
        /// <summary>
        /// Merge two lambdas with And (&&) operator.
        /// </summary>
        /// <param name="left">Left lambda.</param>
        /// <param name="right">Right lambda.</param>
        /// <returns>Merged lambda.</returns>
        public static Expression<Func<TIn, bool>> AndAlso<TIn>(
            this Expression<Func<TIn, bool>> left,
            Expression<Func<TIn, bool>> right)
        {
            var parameterExpression = Expression.Parameter(typeof(TIn));
            var expressionBody = Expression.AndAlso(left.Body, right.Body);

            expressionBody = (BinaryExpression)new ParameterReplacer(parameterExpression)
                .Visit(expressionBody);

            return Expression.Lambda<Func<TIn, Boolean>>(expressionBody, parameterExpression);
        }

        /// <summary>
        /// Merge two lambdas with Or (||) operator.
        /// </summary>
        /// <param name="left">Left lambda.</param>
        /// <param name="right">Right lambda.</param>
        /// <returns>Merged lambda.</returns>
        public static Expression<Func<TIn, bool>> Or<TIn>(
            this Expression<Func<TIn, bool>> left,
            Expression<Func<TIn, bool>> right)
        {
            var parameterExpression = Expression.Parameter(typeof(TIn));
            var expressionBody = Expression.Or(left.Body, right.Body);

            expressionBody = (BinaryExpression)new ParameterReplacer(parameterExpression)
                .Visit(expressionBody);

            return Expression.Lambda<Func<TIn, bool>>(expressionBody, parameterExpression);
        }
    }
}
