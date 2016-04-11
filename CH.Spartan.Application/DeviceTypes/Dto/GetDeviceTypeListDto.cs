using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CH.Spartan.Commons;

namespace CH.Spartan.DeviceTypes.Dto
{
    [AutoMapFrom(typeof(DeviceType))]
    public class GetDeviceTypeListDto : AuditedEntityDto
    {
        /// <summary>
        /// 设备类型名字
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 接入网关
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string SwitchInGateway { get; set; }

        /// <summary>
        /// 供应商
        /// </summary>
        [Required]
        [MaxLength(150)]
        public string Supplier { get; set; }

        /// <summary>
        /// 制造商
        /// </summary>
        [Required]
        [MaxLength(150)]
        public string Manufacturer { get; set; }

        /// <summary>
        /// 服务费元/年
        /// </summary>
        public decimal ServiceCharge { get; set; }

    }

    public class GetDeviceTypeListInput : QueryListResultRequestInput
    {

    }

    public class GetDeviceTypeListPagedInput : QueryListPagedResultRequestInput
    {

    }
}
