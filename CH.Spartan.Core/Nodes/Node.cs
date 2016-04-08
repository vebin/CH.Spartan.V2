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
        /// <summary>
        /// 节点KEY 
        /// </summary>
        [MaxLength(50)]
        public string Key { get; set; }

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

        /// <summary>
        /// 据库连接
        /// </summary>
        [MaxLength(250)]
        public string HistoryConnectionString { get; set; }
    }
}
