using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace CH.Spartan.Devices.Dto
{
    [AutoMap(typeof(Device))]
    public class CreateDeviceByAgentDto : IDoubleWayDto
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
        /// 设备类型Id
        /// </summary>
        public int BDeviceTypeId { get; set; }

        /// <summary>
        /// 设备号
        /// </summary>
        [Required]
        public string BNo { get; set; }

        /// <summary>
        /// Sim号
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
        public long UserId { get; set; }

    }

    public class CreateDeviceByAgentInput : IInputDto
    {
        public CreateDeviceByAgentDto Device { get; set; }
    }

    public class CreateDeviceByAgentOutput : IOutputDto
    {
        public CreateDeviceByAgentOutput(CreateDeviceByAgentDto device)
        {
            Device = device;
        }

        public CreateDeviceByAgentDto Device { get; set; }
    }
}


