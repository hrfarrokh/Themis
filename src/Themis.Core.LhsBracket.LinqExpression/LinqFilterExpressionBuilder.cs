using System.Linq.Expressions;
using System.Reflection;
using Themis.Core.LhsBracket.Abstractions;

namespace Themis.Core.LhsBracket.LinqExpression
{
    public static class LinqFilterExpressionBuilder
    {
        public static IQueryable<TEntity> ApplyFilters<TEntity, TKey>(
            this IQueryable<TEntity> source,
            Expression<Func<TEntity, TKey>> selector,
            FilterOperations<TKey>? filters)
        {
            if (filters == null)
                return source;

            var filterExpressions = new List<Expression<Func<TEntity, bool>>>();

            filterExpressions.AddRange(CreateFilters<TEntity, TKey>(selector, filters));
            foreach (var expression in filterExpressions)
            {
                source = source.Where(expression);
            }

            return source;

        }

        private static Func<Expression, Expression, Expression> MapOperationToLinqExpression(
            FilterOperationEnum filterOperationType)
        {
            switch (filterOperationType)
            {
                case FilterOperationEnum.Eq: return Expression.Equal;
                case FilterOperationEnum.Ne: return Expression.NotEqual;
                case FilterOperationEnum.Gt: return Expression.GreaterThan;
                case FilterOperationEnum.Gte: return Expression.GreaterThanOrEqual;
                case FilterOperationEnum.Lt: return Expression.LessThan;
                case FilterOperationEnum.Lte: return Expression.LessThanOrEqual;
                default: throw new Exception($"Couldn't map enum: {filterOperationType.ToString()}");
            }
        }

        private static List<Expression<Func<TEntity, bool>>> CreateFilters<TEntity, TKey>(
            Expression<Func<TEntity, TKey>> selector,
            FilterOperations<TKey> filterOperations)
        {
            var expressions = new List<Expression<Func<TEntity, bool>>>();

            foreach (var filterOperation in filterOperations)
            {
                if (!filterOperation.hasMultipleValues && filterOperation.values.Count() > 0)
                {
                    var linqOperationExp = MapOperationToLinqExpression(filterOperation.operation);
                    var linqExpression = CreateBasicExpression(linqOperationExp,
                                                               selector,
                                                               filterOperation.values.First());
                    expressions.Add(linqExpression);
                }
                else
                {
                    var linqContainsExpression = CreateContainsExpression(selector,
                                                                          filterOperation.values,
                                                                          filterOperation.operation
                                                                          == FilterOperationEnum.Nin);
                    expressions.Add(linqContainsExpression);
                }
            }

            return expressions;
        }



        /// <summary>
        /// it is nasty AF to work with list of nullables so we just use right hand side's type as it is and convert left to be the same
        /// </summary>
        private static Expression<Func<TEntity, bool>> CreateContainsExpression<TEntity, TKey>(
            Expression<Func<TEntity, TKey>> selector,
            IEnumerable<TKey> values,
            bool invert = false)
        {
            (var left, var param) = CreateLeftExpression(selector);
            left = Expression.Convert(left, typeof(TKey));
            Expression right = Expression.Constant(values);

            var containsMethodRef = typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                   .Single(m => m.Name == nameof(Enumerable.Contains) && m.GetParameters().Length == 2);
            MethodInfo containsMethod = containsMethodRef.MakeGenericMethod(typeof(TKey));

            Expression containsExpression = Expression.Call(containsMethod, right, left);
            if (invert == true) containsExpression = Expression.Not(containsExpression);

            var lambdaExpression = Expression.Lambda<Func<TEntity, bool>>(containsExpression, param);
            return lambdaExpression;
        }

        private static Expression<Func<TEntity, bool>> CreateBasicExpression<TEntity, TKey>(
            Func<Expression, Expression, Expression> expressionOperator,
            Expression<Func<TEntity, TKey>> selector,
            TKey value)
        {
            (var left, var param) = CreateLeftExpression(selector);
            var nullableType = MakeNullableType(typeof(TKey)); // we need to convert stuff to the same type so they are aligned
            left = Expression.Convert(left, nullableType);
            Expression right = Expression.Constant(value, nullableType);

            var finalExpression = expressionOperator.Invoke(left, right);
            var lambdaExpression = Expression.Lambda<Func<TEntity, bool>>(finalExpression, param);
            return lambdaExpression;
        }

        /// <summary>
        /// This will take care of nested navigation properties as well
        /// </summary>
        static (Expression Left, ParameterExpression Param) CreateLeftExpression<TEntity, TKey>(
            Expression<Func<TEntity, TKey>> selector)
        {
            var parameterName = "x";
            var parameter = Expression.Parameter(typeof(TEntity), parameterName);

            var propertyName = GetParameterName(selector);
            var memberExpression = (Expression)parameter;
            foreach (var member in propertyName.Split('.').Skip(1))
            {
                memberExpression = Expression.PropertyOrField(memberExpression, member);
            }
            return (memberExpression, parameter);
        }

        private static string GetParameterName<TEntity, TKey>(Expression<Func<TEntity, TKey>> expression)
        {
            // this is the case for datetimes, enums and possibly others. Possibly navigation properties.
            if (!(expression.Body is MemberExpression memberExpression))
            {
                memberExpression = (MemberExpression)((UnaryExpression)expression.Body).Operand;
            }

            // // x.Category.Name will become Name
            return memberExpression.ToString();
        }

        private static Type MakeNullableType(Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                return type;

            if (type == typeof(string))
                return type;

            return typeof(Nullable<>).MakeGenericType(type);
        }
    }
}
