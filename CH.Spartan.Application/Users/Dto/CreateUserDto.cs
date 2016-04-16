using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace CH.Spartan.Users.Dto
{
    [AutoMap(typeof (User))]
    public class CreateUserDto : IDoubleWayDto
    {
        /// <summary>
        /// 所属租户
        /// </summary>
        public int? TenantId { get; set; }

        /// <summary>
        /// 用户名 hhahh2011
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 邮件
        /// </summary>
        public string EmailAddress { get; set; }
    }

    public class CreateUserInput : IInputDto
    {
        public CreateUserDto User { get; set; }
    }

    public class CreateUserOutput : IOutputDto
    {
        public CreateUserOutput(CreateUserDto user)
        {
            User = user;
        }

        public CreateUserDto User { get; set; }
    }
}


