using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace CH.Spartan.Areas
{
    public class AreaSetting
    {
        /// <summary>
        /// 区域Id
        /// </summary>
        public int AreaId { get; set; }

        /// <summary>
        /// 是否为进入区域
        /// </summary>
        public bool IsInArea { get; set; }
    }
}
