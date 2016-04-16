using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CH.Spartan.Infrastructure;

namespace CH.Spartan.Users.Dto
{
    [AutoMapFrom(typeof(User))]
    public class GetUserListDto : AuditedEntityDto
    {
        /// <summary>
        /// 用户名 hhahh2011
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 名称 陈欢
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 昵称 西瓜
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// 邮件
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime? LastLoginTime { get; set; }

        /// <summary>
        /// 是否激活
        /// </summary>
        public string IsActiveText { get; set; }

        /// <summary>
        /// 所属租户
        /// </summary>
        public string TenantText { get; set; }

    }

    public class GetUserListInput : QueryListResultRequestInput
    {

    }

    public class GetUserListPagedInput : QueryListPagedResultRequestInput
    {
        /// <summary>
        /// 是否激活
        /// </summary>
       public bool? IsActive { get; set; }
    }
}
