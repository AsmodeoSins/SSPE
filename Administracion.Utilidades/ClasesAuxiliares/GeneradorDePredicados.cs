using Administracion.Utilidades.ClasesAuxiliares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Administracion.Utilidades
{
    /// <summary>
    /// Clase para la generacion dinamica de predicados
    /// </summary>
    public static class GeneradorDePredicados
    {
        public static Expression<Func<T, bool>> True<T>() { return f => true; }
        public static Expression<Func<T, bool>> False<T>() { return f => false; }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1,
                                                            Expression<Func<T, bool>> expr2)
        {
            if (expr1 == null)
            {
                return expr2;
            }

            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                  (Expression.OrElse(expr1.Body, invokedExpr), expr1.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1,
                                                             Expression<Func<T, bool>> expr2)
        {
            if (expr1 == null)
            {
                return expr2;
            }

            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                  (Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);

        }

        // allows extension to other signatures later...
        private static Expression<TTo> ConvertImpl<TFrom, TTo>(Expression<TFrom> from)
            where TFrom : class
            where TTo : class
        {
            // figure out which types are different in the function-signature
            var fromTypes = from.Type.GetGenericArguments();
            var toTypes = typeof(TTo).GetGenericArguments();
            if (fromTypes.Length != toTypes.Length)
                throw new NotSupportedException(
                    "Incompatible lambda function-type signatures");
            Dictionary<Type, Type> typeMap = new Dictionary<Type, Type>();
            for (int i = 0; i < fromTypes.Length; i++)
            {
                if (fromTypes[i] != toTypes[i])
                    typeMap[fromTypes[i]] = toTypes[i];
            }

            // re-map all parameters that involve different types
            Dictionary<Expression, Expression> parameterMap
                = new Dictionary<Expression, Expression>();
            ParameterExpression[] newParams =
                new ParameterExpression[from.Parameters.Count];
            for (int i = 0; i < newParams.Length; i++)
            {
                Type newType;
                if (typeMap.TryGetValue(from.Parameters[i].Type, out newType))
                {
                    parameterMap[from.Parameters[i]] = newParams[i] =
                        Expression.Parameter(newType, from.Parameters[i].Name);
                }
                else
                {
                    newParams[i] = from.Parameters[i];
                }
            }

            // rebuild the lambda
            var body = new ConversorDePredicados(parameterMap).Visit(from.Body);
            return Expression.Lambda<TTo>(body, newParams);
        }

        public static Expression<Func<TTo, bool>> Convertir<TFrom, TTo>(
        this Expression<Func<TFrom, bool>> from)
        {
            return ConvertImpl<Func<TFrom, bool>, Func<TTo, bool>>(from);
        }
    }
}
