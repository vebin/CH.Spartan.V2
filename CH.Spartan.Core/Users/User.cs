using System;
using System.ComponentModel.DataAnnotations;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Extensions;
using CH.Spartan.MultiTenancy;
using Microsoft.AspNet.Identity;

namespace CH.Spartan.Users
{
    public class User : AbpUser<Tenant, User>
    {
        #region 基本
        /// <summary>
        /// 是否初始用户名
        /// </summary>
        public bool IsInitUserName { get; set; }

        /// <summary>
        /// 是否初始密码
        /// </summary>
        public bool IsInitPassword { get; set; }

        #endregion

        #region 设置

        /// <summary>
        /// 报警是否开启
        /// </summary>
        public bool SIsEnableAlarm { get; set; }

        /// <summary>
        /// 报警信息报警声音
        /// </summary>
        [MaxLength(100)]
        public string SAlarmSound { get; set; }

        /// <summary>
        /// 报警信息是否发送邮件
        /// </summary>
        public bool SIsSendEmail { get; set; }

        /// <summary>
        /// 报警信息是否发送APP
        /// </summary>
        public bool SIsSendApp { get; set; }

        /// <summary>
        /// 接收报警类型
        /// </summary>
        public EnumAlarmType SReceiveAlarmType { get; set; }

        /// <summary>
        /// 报警信息接收邮件列表
        /// </summary>
        [MaxLength(250)]
        public string SReceiveEmails { get; set; }

        /// <summary>
        /// 报警信息允许接收开始时间
        /// </summary>
        public TimeSpan SReceiveStartTime { get; set; }

        /// <summary>
        /// 报警信息允许接收结束时间
        /// </summary>
        public TimeSpan SReceiveEndTime { get; set; }

        /// <summary>
        /// 报警设防半径
        /// </summary>
        public int SFortifyRadius { get; set; }

        #endregion

        #region 绑定

        /// <summary>
        /// QQ互联唯一Id
        /// </summary>
        [MaxLength(200)]
        public string QQOpenId { get; set; }

        /// <summary>
        /// QQ互联访问口令
        /// </summary>
        [MaxLength(200)]
        public string QQAccessToken { get; set; }


        /// <summary>
        /// QQ互联访问过期时间
        /// </summary>
        public int? QQExpiresIn { get; set; }

        /// <summary>
        /// 微信唯一Id
        /// </summary>
        [MaxLength(200)]
        public string WeiXinUnionId { get; set; }

        /// <summary>
        /// 微信访问口令
        /// </summary>
        [MaxLength(200)]
        public string WeiXinAccessToken { get; set; }


        /// <summary>
        /// 微信访问过期时间
        /// </summary>
        public int? WeiXinExpiresIn { get; set; }


        /// <summary>
        /// 微博唯一Id
        /// </summary>
        [MaxLength(200)]
        public string WeiBoOpenId { get; set; }

        /// <summary>
        /// 微博访问口令
        /// </summary>
        [MaxLength(200)]
        public string WeiBoAccessToken { get; set; }

        /// <summary>
        /// 微博访问过期时间
        /// </summary>
        public int? WeiBoExpiresIn { get; set; } 
        #endregion

        #region 方法

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(int tenantId, string userName, string emailAddress, string password)
        {
            return new User
            {
                TenantId = tenantId,
                UserName = userName,
                Name = userName,
                Surname = userName,
                IsEmailConfirmed = true,
                EmailAddress = emailAddress,
                IsActive = true,
                IsInitPassword = true,
                IsInitUserName = true,
                SIsEnableAlarm = true,
                SFortifyRadius = 100,
                SIsSendApp = true,
                SIsSendEmail = false,
                SReceiveStartTime = new TimeSpan(8, 0, 0),
                SReceiveEndTime = new TimeSpan(23, 59, 59),
                SAlarmSound = "default",
                Password = new Md532PasswordHasher().HashPassword(password)
            };
        }
        public static User CreateTenantUser(int tenantId, string userName, string emailAddress, string password)
        {
            return new User
            {
                TenantId = tenantId,
                UserName = userName,
                Name = userName,
                Surname = userName,
                IsEmailConfirmed = true,
                EmailAddress = emailAddress,
                IsActive = true,
                IsInitPassword = true,
                IsInitUserName = true,
                SIsEnableAlarm=true,
                SFortifyRadius = 100,
                SIsSendApp = true,
                SIsSendEmail = false,
                SReceiveStartTime = new TimeSpan(8,0,0),
                SReceiveEndTime = new TimeSpan(23, 59, 59),
                SAlarmSound = "default",
                Password = new Md532PasswordHasher().HashPassword(password)
            };
        }

        #endregion

    }
}