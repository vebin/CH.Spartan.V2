using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace CH.Spartan.Devices.Dto
{
    [AutoMap(typeof(Device))]
    public class UpdateDeviceByAgentDto : EntityDto, IDoubleWayDto
    {
        /// <summary>
        /// 设备名字
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string BName { get; set; }

        /// <summary>
        /// 车牌号
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string BLicensePlate { get; set; }

        /// <summary>
        /// 设备图标类型
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string BIconType { get; set; }

        /// <summary>
        /// 设备类型Id
        /// </summary>
        public int BDeviceTypeId { get; set; }

        /// <summary>
        /// 设备号
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string BNo { get; set; }

        /// <summary>
        /// 设备唯一编码不同的设备编码生成规则不一样
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string BCode { get; set; }

        /// <summary>
        /// Sim号
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string BSimNo { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime? BExpireTime { get; set; }

        /// <summary>
        /// 所属节点Id
        /// </summary>
        public int BNodeId { get; set; }

        /// <summary>
        /// 报警设置超限速
        /// </summary>
        public int SLimitSpeed { get; set; }

        /// <summary>
        /// 报警设置进出区域
        /// </summary>
        public bool SInOutArea { get; set; }

        /// <summary>
        /// 所属租户Id
        /// </summary>
        public int TenantId { get; set; }

        /// <summary>
        /// 所属用户Id
        /// </summary>
        public long UserId { get; set; }

    }

    public class UpdateDeviceByAgentInput : IInputDto
    {
        public UpdateDeviceByAgentDto Device { get; set; }
    }

    public class UpdateDeviceByAgentOutput : IOutputDto
    {
        public UpdateDeviceByAgentOutput(UpdateDeviceByAgentDto device)
        {
            Device = device;
        }

        public UpdateDeviceByAgentDto Device { get; set; }
    }
}
