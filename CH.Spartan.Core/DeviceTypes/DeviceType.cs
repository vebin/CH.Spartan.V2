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
        /// 设备所使用协议
        /// </summary>
        public EnumProtocol Protocol { get; set; }

        /// <summary>
        /// 设备唯一编码生成规则
        /// </summary>
        public EnumCodeCreateRule CodeCreateRule { get; set; }

        /// <summary>
        /// 是否有继电器
        /// </summary>
        public bool IsHaveRelay { get; set; }

        /// <summary>
        /// 是否有外接电源
        /// </summary>
        public bool IsHaveMainPowerBreak { get; set; }

        /// <summary>
        /// 是否有SOS报警
        /// </summary>
        public bool IsHaveSos { get; set; }

        /// <summary>
        /// 是否有脱落报警
        /// </summary>
        public bool IsHaveDropOff { get; set; }

        /// <summary>
        /// 是否有震动报警
        /// </summary>
        public bool IsHaveShake { get; set; }

        /// <summary>
        /// 是否有低电报警
        /// </summary>
        public bool IsHaveLowBattery { get; set; }

        /// <summary>
        /// 是否有电量数据
        /// </summary>
        public bool IsHavePower { get; set; }

        /// <summary>
        /// 是否有Acc信号
        /// </summary>
        public bool IsHaveAcc { get; set; }

        /// <summary>
        /// 设备集合
        /// </summary>
        public ICollection<Device> Devices { get; set; }
    }
}
