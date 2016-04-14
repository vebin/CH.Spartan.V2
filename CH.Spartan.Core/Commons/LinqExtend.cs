using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Extensions;

namespace CH.Spartan.Commons
{
    public static class LinqExtend
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, ISortedResultRequest sorted)
        {
            if (sorted.Sorting.IsNullOrEmpty())
            {
                return source;
            }

            return source.OrderBy(sorted.Sorting);
        }

        public static IQueryable<T> Take<T>(this IQueryable<T> source, ILimitedResultRequest limited)
        {
            if (limited.MaxResultCount<=0)
            {
                return source;
            }

            return source.Take(limited.MaxResultCount);
        }
    }
}
