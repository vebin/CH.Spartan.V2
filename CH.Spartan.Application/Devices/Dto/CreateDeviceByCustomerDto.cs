using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace CH.Spartan.Devices.Dto
{
    [AutoMap(typeof(Device))]
    public class CreateDeviceByCustomerDto : IDoubleWayDto
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

    }

    public class CreateDeviceByCustomerInput : IInputDto
    {
        public CreateDeviceByCustomerDto Device { get; set; }
    }

    public class CreateDeviceByCustomerOutput : IOutputDto
    {
        public CreateDeviceByCustomerOutput(CreateDeviceByCustomerDto device)
        {
            Device = device;
        }

        public CreateDeviceByCustomerDto Device { get; set; }

        public int ExpireYear { get; set; }
    }
}


