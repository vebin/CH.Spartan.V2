using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using System.Linq.Dynamic;
using System.Data.Entity;
using Abp.Extensions;

namespace CH.Spartan.Commons.Linq
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
    }
}
