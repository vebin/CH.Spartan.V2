using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using CH.Spartan.Devices;

namespace CH.Spartan.DeviceTypes
{

    public class DeviceType : FullAuditedEntity
    {

        /// <summary>
        /// 设备类型名字
        /// </summary>
        [Required,MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 接入网关
        /// </summary>
        [Required, MaxLength(50)]
        public string SwitchInGateway { get; set; }
        
        /// <summary>
        /// 供应商
        /// </summary>
        [Required, MaxLength(150)]
        public string Supplier { get; set; }

        /// <summary>
        /// 制造商
        /// </summary>
        [Required, MaxLength(150)]
        public string Manufacturer { get; set; }

        /// <summary>
        /// 服务费 元/年
        /// </summary>
        public decimal ServiceCharge { get; set; }

        /// <summary>
        /// 设备唯一编码生成规则
        /// </summary>
        [Required]
        public EnumCodeCreateRule CodeCreateRule { get; set; }

        /// <summary>
        /// 是否有继电器
        /// </summary>
        public bool IsHaveRelay { get; set; }

        /// <summary>
        /// 拥有报警功能
        /// </summary>
        public EnumAlarmType HaveAlarmType { get; set; }
    }
}
