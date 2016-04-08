using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace CH.Spartan.DeviceTypes.Dto
{
    [AutoMap(typeof(DeviceType))]
    public class UpdateDeviceTypeDto : EntityDto, IDoubleWayDto
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
        [Required]
        [Range(1, 500)]
        public decimal ServiceCharge { get; set; }

        /// <summary>
        /// 设备唯一编码生成规则
        /// </summary>
        [Required]
        public EnumCodeCreateRule CodeCreateRule { get; set; }

        /// <summary>
        /// 是否有继电器
        /// </summary>
        public bool IsHaveRelay { get; set; }

        /// <summary>
        /// 拥有报警
        /// </summary>
        public EnumAlarmType HaveAlarmType { get; set; }

    }

    public class UpdateDeviceTypeInput : IInputDto
    {
        public UpdateDeviceTypeDto DeviceType { get; set; }
    }

    public class UpdateDeviceTypeOutput : IOutputDto
    {
        public UpdateDeviceTypeOutput(UpdateDeviceTypeDto deviceType)
        {
            DeviceType = deviceType;
        }

        public UpdateDeviceTypeDto DeviceType { get; set; }
    }
}
