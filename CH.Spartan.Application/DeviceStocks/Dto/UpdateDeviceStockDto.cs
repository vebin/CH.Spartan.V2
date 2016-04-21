using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CH.Spartan.Infrastructure;
namespace CH.Spartan.DeviceStocks.Dto
{
    [AutoMap(typeof(DeviceStock))]
    public class UpdateDeviceStockDto : EntityDto, IDoubleWayDto
    {
        /// <summary>
        /// 设备号
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string No { get; set; }

    }

    public class UpdateDeviceStockInput : IInputDto
    {
        public UpdateDeviceStockDto DeviceStock { get; set; }
    }

    public class UpdateDeviceStockOutput : IOutputDto
    {
        public UpdateDeviceStockOutput(UpdateDeviceStockDto deviceStock)
        {
            DeviceStock = deviceStock;
        }

        public UpdateDeviceStockDto DeviceStock { get; set; }
    }
}
