using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CH.Spartan.Infrastructure;
namespace CH.Spartan.DeviceStocks.Dto
{
    [AutoMap(typeof(DeviceStock))]
    public class GetDeviceStockDto : EntityDto, IOutputDto
    {
        /// <summary>
        /// 设备号
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string No { get; set; }

    }

    public class GetDeviceStockInput : IInputDto
    {
        public GetDeviceStockDto DeviceStock { get; set; }
    }

    public class GetDeviceStockOutput : IOutputDto
    {
        public GetDeviceStockOutput(GetDeviceStockDto deviceStock)
        {
            DeviceStock = deviceStock;
        }

        public GetDeviceStockDto DeviceStock { get; set; }
    }
}


