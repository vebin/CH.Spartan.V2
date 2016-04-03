﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Extensions;
using Abp.Runtime.Validation;

namespace CH.Spartan.Commons.Dto
{
    public interface IFilterResultRequest
    {
        string SearchText { get; set; }
    }


    public interface IDateTimeResultRequest
    {
        DateTime? StarTime { get; set; }
        DateTime? EndTime { get; set; }
    }

    public class QueryResultRequestInput :
        IDateTimeResultRequest,
        IFilterResultRequest,
        ISortedResultRequest,
        IPagedResultRequest,
        IShouldNormalize
    {
        public DateTime? StarTime { get; set; }

        public DateTime? EndTime { get; set; }

        public string SearchText { get; set; }

        public string Sorting { get; set; }

        public int MaxResultCount { get; set; }

        public int SkipCount { get; set; }

        public void Normalize()
        {
            if (Sorting.IsNullOrEmpty())
            {
                Sorting = SpartanConsts.DefaultSorting;
            }
            if (MaxResultCount == 0)
            {
                MaxResultCount = SpartanConsts.DefaultMaxResultCount;
            }
        }
    }
}
