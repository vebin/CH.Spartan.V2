using System;
using Abp.Application.Services.Dto;
using Abp.Auditing;
using Abp.AutoMapper;
using CH.Spartan.Infrastructure;

namespace CH.Spartan.AuditLogs.Dto
{
    [AutoMapFrom(typeof(AuditLog))]
    public class GetAuditLogListDto : AuditedEntityDto
    {
        /// <summary>
        /// 所属模块类或者接口
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// 执行方法名
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        /// 执行方法参数
        /// </summary>
        public string Parameters { get; set; }

        /// <summary>
        /// 执行方法开始时间
        /// </summary>
        public DateTime ExecutionTime { get; set; }

        /// <summary>
        /// 执行方法耗时毫秒
        /// </summary>
        public int ExecutionDuration { get; set; }

        /// <summary>
        /// 客户端IP
        /// </summary>
        public string ClientIpAddress { get; set; }

        /// <summary>
        /// 客户端机器名
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// 浏览器
        /// </summary>
        public string BrowserInfo { get; set; }

        /// <summary>
        /// 异常.
        /// </summary>
        public string Exception { get; set; }

        /// <summary>
        /// 自定义数据
        /// </summary>
        public string CustomData { get; set; }

    }

    public class GetAuditLogListInput : QueryListResultRequestInput
    {

    }

    public class GetAuditLogListPagedInput : QueryListPagedResultRequestInput
    {

    }
}
