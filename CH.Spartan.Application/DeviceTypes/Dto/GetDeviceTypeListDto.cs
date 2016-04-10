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

        /// <summary>
        /// 设备唯一编码生成规则
        /// </summary>
        [Required]
        public EnumCodeCreateRule CodeCreateRule { get; set; }

        /// <summary>
        /// 是否有继电器1
        /// </summary>
        public bool IsHaveRelay1 { get; set; }

        /// <summary>
        /// 是否有继电器2
        /// </summary>
        public bool IsHaveRelay2 { get; set; }

        /// <summary>
        /// 是否有继电器3
        /// </summary>
        public bool IsHaveRelay3 { get; set; }

        /// <summary>
        /// 是否有电量数据
        /// </summary>
        public bool IsHavePower { get; set; }

        /// <summary>
        /// 是否有Acc信号
        /// </summary>
        public bool IsHaveAcc { get; set; }

        /// <summary>
        /// 是否有离线报警
        /// </summary>
        public bool IsHaveOffLine { get; set; }

        /// <summary>
        /// 是否有断电报警
        /// </summary>
        public bool IsHaveMainPowerBreak { get; set; }

        /// <summary>
        /// 是否有SOS求救
        /// </summary>
        public bool IsHaveSos { get; set; }

        /// <summary>
        /// 是否有超速报警
        /// </summary>
        public bool IsHaveOverSpeed { get; set; }

        /// <summary>
        /// 是否有进入区域报警
        /// </summary>
        public bool IsHaveInArea { get; set; }

        /// <summary>
        /// 是否有离开设防报警
        /// </summary>
        public bool IsHaveFortify { get; set; }

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
        /// 是否有进入盲区报警
        /// </summary>
        public bool IsHaveInBlindArea { get; set; }

        /// <summary>
        /// 是否有离开盲区报警
        /// </summary>
        public bool IsHaveOutBlindArea { get; set; }

        /// <summary>
        /// 是否有启动报警报警
        /// </summary>
        public bool IsHaveStartup { get; set; }

    }

    public class GetDeviceTypeListInput : QueryListResultRequestInput
    {

    }

    public class GetDeviceTypeListPagedInput : QueryListPagedResultRequestInput
    {

    }
}
