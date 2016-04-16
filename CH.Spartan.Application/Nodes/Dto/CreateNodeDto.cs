using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace CH.Spartan.Nodes.Dto
{
    [AutoMap(typeof(Node))]
    public class CreateNodeDto : IDoubleWayDto
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

    public class CreateNodeInput : IInputDto
    {
        public CreateNodeDto Node { get; set; }
    }

    public class CreateNodeOutput : IOutputDto
    {
        public CreateNodeOutput(CreateNodeDto node)
        {
            Node = node;
        }

        public CreateNodeDto Node { get; set; }
    }
}


