using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Extensions;

namespace CH.Spartan.Commons
{
    public static class LinqExtend
    {
        #region OrderBy

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, ISortedResultRequest sorted)
        {
            if (sorted.Sorting.IsNullOrEmpty())
            {
                return source;
            }

            return source.OrderBy(sorted.Sorting);
        } 
        #endregion

        #region Take
        public static IQueryable<T> Take<T>(this IQueryable<T> source, ILimitedResultRequest limited)
        {
            if (limited.MaxResultCount <= 0)
            {
                return source;
            }

            return source.Take(limited.MaxResultCount);
        }
        #endregion

        #region WhereDynamic

        public static IQueryable<TSource> WhereIfDynamic<TSource,TValue>(this IQueryable<TSource> source, bool condition,
            string key ,TValue value) where TSource : class
        {
            if (!condition)
            {
                return source;
            }

            var nameValues = new NameValueCollection {[key] = value.ToString()};
            return source.WhereIfDynamic(true, nameValues);
        }

        public static IQueryable<TSource> WhereIfDynamic<TSource>(this IQueryable<TSource> source, bool condition,
            NameValueCollection nameValues) where TSource : class
        {
            if (condition && nameValues.Count > 0)
            {
                //构建 c=>Body中的c
                ParameterExpression param = Expression.Parameter(typeof (TSource), "c");
                //构建c=>Body中的Body
                var body = GetExpressoinBody(param, nameValues);
                if (body != null)
                {
                    //将二者拼为c=>Body
                    var expression = Expression.Lambda<Func<TSource, bool>>(body, param);
                    //传到Where中当做参数，类型为Expression<Func<T,bool>>
                    return source.Where(expression);
                }
            }
            return source;
        }

        private static Expression GetExpressoinBody(ParameterExpression param, NameValueCollection nameValues)
        {
            var list = new List<Expression>();
            if (nameValues.Count > 0)
            {
                var plist = param.Type.GetRuntimeProperties().ToDictionary(z => z.Name);//可以加缓存改善性能
                foreach (var item in nameValues.AllKeys)
                    if (item.EndsWith(">"))//可能大小查询
                    {
                        string key = item.TrimEnd('>');
                        if (!plist.ContainsKey(key) || nameValues[item].Length <= 0) continue;
                        var rType = plist[key].GetMethod.ReturnType;
                        if (rType == typeof(string)) continue;
                        var e1 = Expression.Property(param, key);
                        object dValue;
                        if (TryParser(nameValues[item], rType, out dValue))
                            list.Add(Expression.GreaterThan(e1, Expression.Constant(dValue, rType)));
                    }
                    else if (item.EndsWith("<"))//可能大小查询
                    {
                        string key = item.TrimEnd('<');
                        if (!plist.ContainsKey(key) || nameValues[item].Length <= 0) continue;
                        var rType = plist[key].GetMethod.ReturnType;
                        if (rType == typeof(string)) continue;
                        var e1 = Expression.Property(param, key);
                        object dValue;
                        if (TryParser(nameValues[item], rType, out dValue))
                        {
                            list.Add(Expression.LessThan(e1, Expression.Constant(dValue, rType)));
                        }
                    }
                    else if (plist.ContainsKey(item) && nameValues[item].Length > 0)
                    {
                        var e1 = Expression.Property(param, item);
                        var rType = plist[item].GetMethod.ReturnType;
                        if (rType == typeof(string))//可能是like查询
                        {
                            var value = nameValues[item].Trim('%');
                            var e2 = Expression.Constant(value);
                            if (nameValues[item].Length - value.Length >= 2)
                                list.Add(Expression.Call(e1, "Contains", null, new Expression[] { e2 }));
                            else if (nameValues[item].StartsWith("%"))
                                list.Add(Expression.Call(e1, "EndsWith", null, new Expression[] { e2 }));
                            else if (nameValues[item].EndsWith("%"))
                                list.Add(Expression.Call(e1, "StartsWith", null, new Expression[] { e2 }));
                            else
                                list.Add(Expression.Equal(e1, e2));
                        }

                        else if (nameValues[item].IndexOf(",") > 0)//可能是in查询
                        {
                            if (rType == typeof(short))
                            {
                                var searchList = TryParser<short>(nameValues[item]);
                                if (searchList.Any())
                                    list.Add(Expression.Call(Expression.Constant(searchList, rType), "Contains", null, new Expression[] { e1 }));
                            }
                            else if (rType == typeof(int))
                            {
                                var searchList = TryParser<int>(nameValues[item]);
                                if (searchList.Any())
                                    list.Add(Expression.Call(Expression.Constant(searchList, rType), "Contains", null, new Expression[] { e1 }));
                            }
                            else if (rType == typeof(long))
                            {
                                var searchList = TryParser<long>(nameValues[item]);
                                if (searchList.Any())
                                    list.Add(Expression.Call(Expression.Constant(searchList, rType), "Contains", null, new Expression[] { e1 }));
                            }
                        }
                        else
                        {
                            object dValue;
                            if (TryParser(nameValues[item], rType, out dValue))
                                list.Add(Expression.Equal(e1, Expression.Constant(dValue, rType)));
                        }
                    }
            }
            return list.Count > 0 ? list.Aggregate(Expression.AndAlso) : null;
        }

        private static List<T> TryParser<T>(string value)

        {

            string[] searchArray = value.Split(',');

            List<T> dList = new List<T>();

            foreach (var l in searchArray)

            {

                try

                {

                    T dValue = (T)ConvertTo(l, typeof(T));

                    dList.Add(dValue);

                }

                catch { }

            }

            return dList;

        }

        private static bool TryParser(string value, Type outType, out object dValue)

        {

            try

            {

                dValue = ConvertTo(value, outType);
                return true;

            }

            catch

            {

                dValue = null;

                return false;

            }

        }

        public static object ConvertTo(string value, Type ouType)
        {
            if (!ouType.IsGenericType)
            {
                return Convert.ChangeType(value, ouType);
            }
            else
            {
                var genericTypeDefinition = ouType.GetGenericTypeDefinition();
                if (genericTypeDefinition == typeof(Nullable<>))
                {
                    return Convert.ChangeType(value, Nullable.GetUnderlyingType(ouType));
                }
            }
            return null;
        }

        public static T ConvertTo<T>(this IConvertible convertibleValue)
        {
            if (null == convertibleValue)
            {
                return default(T);
            }

            if (!typeof (T).IsGenericType)
            {
                return (T) Convert.ChangeType(convertibleValue, typeof (T));
            }
            else
            {
                Type genericTypeDefinition = typeof (T).GetGenericTypeDefinition();
                if (genericTypeDefinition == typeof (Nullable<>))
                {
                    return (T) Convert.ChangeType(convertibleValue, Nullable.GetUnderlyingType(typeof (T)));
                }
            }
            throw new InvalidCastException(
                $"Invalid cast from type \"{convertibleValue.GetType().FullName}\" to type \"{typeof (T).FullName}\".");
        }

        #endregion
    }
}
