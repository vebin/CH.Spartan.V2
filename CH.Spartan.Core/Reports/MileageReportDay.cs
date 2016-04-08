using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace CH.Spartan.Reports
{
    public class MileageReportDay : Entity,
        IMustHaveTenant,
        IHasCreationTime,
        IHasModificationTime
    {

        /// <summary>
        /// 设备Id
        /// </summary>
        public int DeviceId { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 租户Id
        /// </summary>
        public int TenantId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? LastModificationTime { get; set; }

        /// <summary>
        /// 报表时间
        /// </summary>
        public DateTime Day { get; set; }

        /// <summary>
        /// 总里程
        /// </summary>
        public double TotalMileage { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 开始经纬度
        /// </summary>
        public string StartLatLng { get; set; }

        /// <summary>
        /// 开始地址
        /// </summary>
        public string StartAddress { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 结束经纬度
        /// </summary>
        [MaxLength(50)]
        public string EndLatLng { get; set; }

        /// <summary>
        /// 结束地址
        /// </summary>
        [MaxLength(50)]
        public string EndAddress { get; set; }
    }
}
