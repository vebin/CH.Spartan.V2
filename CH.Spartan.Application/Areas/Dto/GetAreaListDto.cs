using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CH.Spartan.Infrastructure;
namespace CH.Spartan.Areas.Dto
{
    [AutoMapFrom(typeof(Area))]
    public class GetAreaListDto : AuditedEntityDto
    {
        /// <summary>
        /// 区域名字
        /// </summary>
        [MaxLength(250)]
        public string Name { get; set; }

        /// <summary>
        /// 区域点集合
        /// </summary>
        [MaxLength(500)]
        public string Points { get; set; }

        /// <summary>
        /// 所属用户Id
        /// </summary>
        public long UserId { get; set; }

    }

    public class GetAreaListInput : QueryListResultRequestInput
    {

    }

    public class GetAreaListPagedInput : QueryListPagedResultRequestInput
    {

    }
}
