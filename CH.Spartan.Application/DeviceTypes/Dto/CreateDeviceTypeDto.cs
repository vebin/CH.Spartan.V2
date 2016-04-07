using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace CH.Spartan.DeviceTypes.Dto
{
    [AutoMap(typeof(DeviceType))]
    public class CreateDeviceTypeDto : IDoubleWayDto
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
        [Required, MaxLength(50)]
        public string GatewayInfo { get; set; }

        /// <summary>
        /// 是否有继电器
        /// </summary>
        public bool IsHaveRelay { get; set; }

        /// <summary>
        /// 是否有外接电源
        /// </summary>
        public bool IsHaveMainPowerBreak { get; set; }

        /// <summary>
        /// 是否有SOS报警
        /// </summary>
        public bool IsHaveSos { get; set; }

        /// <summary>
        /// 是否有脱落报警
        /// </summary>
        public bool IsHaveDropOff { get; set; }

        /// <summary>
        /// 是否有震动报警
        /// </summary>
        public bool IsHaveShake { get; set; }

        /// <summary>
        /// 是否有低电报警
        /// </summary>
        public bool IsHaveLowBattery { get; set; }

        /// <summary>
        /// 是否有电量数据
        /// </summary>
        public bool IsHavePower { get; set; }

        /// <summary>
        /// 是否有Acc信号
        /// </summary>
        public bool IsHaveAcc { get; set; }

    }

    public class CreateDeviceTypeInput : IInputDto
    {
        public CreateDeviceTypeDto DeviceType { get; set; }
    }

    public class CreateDeviceTypeOutput : IOutputDto
    {
        public CreateDeviceTypeOutput(CreateDeviceTypeDto deviceType)
        {
            DeviceType = deviceType;
        }

        public CreateDeviceTypeDto DeviceType { get; set; }
    }
}


