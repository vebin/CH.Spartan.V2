using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace CH.Spartan.Nodes.Dto
{
    [AutoMap(typeof(Node))]
    public class UpdateNodeDto : EntityDto, IDoubleWayDto
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

    public class UpdateNodeInput : IInputDto
    {
        public UpdateNodeDto Node { get; set; }
    }

    public class UpdateNodeOutput : IOutputDto
    {
        public UpdateNodeOutput(UpdateNodeDto node)
        {
            Node = node;
        }

        public UpdateNodeDto Node { get; set; }
    }
}
