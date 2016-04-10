using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CH.Spartan.Commons;

namespace CH.Spartan.Nodes.Dto
{
    [AutoMapFrom(typeof(Node))]
    public class GetNodeListDto : AuditedEntityDto
    {
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

    public class GetNodeListInput : QueryListResultRequestInput
    {

    }

    public class GetNodeListPagedInput : QueryListPagedResultRequestInput
    {

    }
}
