using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CH.Spartan.Infrastructure;
namespace CH.Spartan.Areas.Dto
{
    [AutoMap(typeof(Area))]
    public class GetAreaDto : EntityDto, IOutputDto
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

    public class GetAreaInput : IInputDto
    {
        public GetAreaDto Area { get; set; }
    }

    public class GetAreaOutput : IOutputDto
    {
        public GetAreaOutput(GetAreaDto area)
        {
            Area = area;
        }

        public GetAreaDto Area { get; set; }
    }
}


