using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace CH.Spartan.Commons.Dto
{
    public interface IFilterResultRequest
    {
        string Filter { get; set; }
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
        IPagedResultRequest
    {
        public DateTime? StarTime { get; set; }

        public DateTime? EndTime { get; set; }

        public string Filter { get; set; }

        public string Sorting { get; set; }

        public int MaxResultCount { get; set; }

        public int SkipCount { get; set; }
    }
}
