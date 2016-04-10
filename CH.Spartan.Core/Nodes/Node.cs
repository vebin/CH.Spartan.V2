using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace CH.Spartan.Nodes
{
    public class Node : FullAuditedEntity
    {

        #region 常量
        public const string T1 = "T1";

        public const string T2 = "T2";

        public const string T3 = "T3";

        public const string T4 = "T4";

        public const string T5 = "T5";
        #endregion

        /// <summary>
        /// 节点名字
        /// </summary>
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 历史数据表
        /// </summary>
        [MaxLength(250)]
        public string HistoryTableName { get; set; }
    }
}
