using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CH.Spartan.Infrastructure;
namespace CH.Spartan.DeviceStocks.Dto
{
    [AutoMapFrom(typeof(DeviceStock))]
    public class GetDeviceStockListDto : AuditedEntityDto
          {
        /// <summary>
        /// 设备号
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string No { get; set; }

}

    public class GetDeviceStockListInput : QueryListResultRequestInput
    {

    }

    public class GetDeviceStockListPagedInput : QueryListPagedResultRequestInput
    {

    }
}
