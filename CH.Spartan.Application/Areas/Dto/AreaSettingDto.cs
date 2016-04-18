using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;

namespace CH.Spartan.Areas.Dto
{
    [AutoMapFrom(typeof(AreaSetting))]
    public class AreaSettingDto
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
