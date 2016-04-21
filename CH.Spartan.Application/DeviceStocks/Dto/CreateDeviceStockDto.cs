using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CH.Spartan.Infrastructure;
namespace CH.Spartan.DeviceStocks.Dto
{
    [AutoMap(typeof(DeviceStock))]
    public class CreateDeviceStockDto : IDoubleWayDto
    {
        /// <summary>
        /// 设备号
        /// </summary>
        [Required]
        public string Nos { get; set; }

    }

    public class CreateDeviceStockInput : IInputDto
    {
        public CreateDeviceStockDto DeviceStock { get; set; }
    }

    public class CreateDeviceStockOutput : IOutputDto
    {
        public CreateDeviceStockOutput(CreateDeviceStockDto deviceStock)
        {
            DeviceStock = deviceStock;
        }

        public CreateDeviceStockDto DeviceStock { get; set; }
    }
}


