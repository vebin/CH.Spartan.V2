using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace CH.Spartan.Users.Dto
{
    [AutoMap(typeof(User))]
    public class UpdateUserDto : EntityDto, IDoubleWayDto
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
        /// 是否激活
        /// </summary>
        public bool IsActive { get; set; }

    }

    public class UpdateUserInput : IInputDto
    {
        public UpdateUserDto User { get; set; }
    }

    public class UpdateUserOutput : IOutputDto
    {
        public UpdateUserOutput(UpdateUserDto user)
        {
            User = user;
        }

        public UpdateUserDto User { get; set; }
    }
}
