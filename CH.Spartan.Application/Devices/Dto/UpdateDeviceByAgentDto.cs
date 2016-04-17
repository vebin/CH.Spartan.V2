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
        /// 设备描述
        /// </summary>
        [MaxLength(100)]
        public string BDscription { get; set; }

        /// <summary>
        /// 设备类型Id
        /// </summary>
        [Required, Range(1, int.MaxValue)]
        public int BDeviceTypeId { get; set; }

        /// <summary>
        /// 设备号
        /// </summary>
        [Required]
        public string BNo { get; set; }

        /// <summary>
        /// 设备卡号
        /// </summary>
        [Required]
        public string BSimNo { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime? BExpireTime { get; set; }

        /// <summary>
        /// 所属用户Id
        /// </summary>
        [Required, Range(1, long.MaxValue)]
        public long UserId { get; set; }

        /// <summary>
        /// 报警设置超限速
        /// </summary>
        public int SLimitSpeed { get; set; }

        /// <summary>
        /// 报警设置进出区域
        /// </summary>
        public string SInOutArea { get; set; }

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
