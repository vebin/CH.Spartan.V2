using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH.Spartan.Infrastructure
{
    public static class SpartanSettingKeys
    {
        #region 通用

        /// <summary>
        /// 是否开启发送邮件
        /// </summary>
        public const string General_Mail_IsEnable= "General.Mail.IsEnable";

        /// <summary>
        /// 发送人邮箱密码
        /// </summary>
        public const string General_Mail_Password = "General.Mail.Password";

        /// <summary>
        /// 发送服务器端口号
        /// </summary>
        public const string General_Mail_Port = "General.Mail.Port";

        /// <summary>
        /// 发送人邮箱
        /// </summary>
        public const string General_Mail_Send_Email = "General.Mail.Send.Email";

        /// <summary>
        /// 发送邮件服务器(Smtp)
        /// </summary>
        public const string General_Mail_Smtp = "General.Mail.Smtp";

        /// <summary>
        /// 发送人邮箱名字
        /// </summary>
        public const string General_Mail_UserName = "General.Mail.UserName";

        /// <summary>
        /// 高德地图密钥(ak)
        /// </summary>
        public const string General_Map_AMapAk = "General.Map.AMapAk";

        /// <summary>
        /// 百度地图密钥(ak)
        /// </summary>
        public const string General_Map_BaiduAk = "General.Map.BaiduAk";

        /// <summary>
        /// 推送AppKey
        /// </summary>
        public const string General_Push_AppKey = "General.Push.AppKey";

        /// <summary>
        /// 允许推送
        /// </summary>
        public const string General_Push_IsEnable = "General.Push.IsEnable";

        /// <summary>
        /// 推送MasterSecret
        /// </summary>
        public const string General_Push_Master_Secret = "General.Push.Master.Secret";


        /// <summary>
        /// QQ登录接入Id
        /// </summary>
        public const string General_QQ_AppId = "General.QQ.AppId";

        /// <summary>
        /// QQ登录接入密钥
        /// </summary>
        public const string General_QQ_AppSecrett = "General.QQ.AppSecrett";


        /// <summary>
        /// 微信接口地址
        /// </summary>
        public const string General_WeChat_ApiUrl = "General.WeChat.ApiUrl";

        /// <summary>
        /// 微信应用接入Id
        /// </summary>
        public const string General_WeChat_AppId = "General.WeChat.AppId";

        /// <summary>
        /// 微信应用接入密钥
        /// </summary>
        public const string General_WeChat_AppSecret = "General.WeChat.AppSecret";

        /// <summary>
        /// 微信应用账号
        /// </summary>
        public const string General_WeChat_Id = "General.WeChat.Id";

        /// <summary>
        /// 微信应用加密令牌
        /// </summary>
        public const string General_WeChat_Token = "General.WeChat.Token";

        /// <summary>
        /// 微博登录接入Id
        /// </summary>
        public const string General_WeiBo_AppId = "General.WeiBo.AppId";

        /// <summary>
        /// 微博登录接入密钥
        /// </summary>
        public const string General_WeiBo_AppSecret = "General.WeiBo.AppSecret";

        /// <summary>
        /// 微信登录接入Id
        /// </summary>
        public const string General_WeiXin_AppId = "General.WeiXin.AppId";

        /// <summary>
        /// 微信登录接入密钥
        /// </summary>
        public const string General_WeiXin_AppSecret = "General.WeiXin.AppSecret";


        #endregion

        #region 用户

        /// <summary>
        /// 报警是否开启
        /// </summary>
        public const string User_IsEnableAlarm = "User.IsEnabl.eAlarm";

        /// <summary>
        /// 报警信息报警声音
        /// </summary>
        public const string User_AlarmSound = "User.AlarmSound";

        /// <summary>
        /// 报警信息是否发送邮件
        /// </summary>
        public const string User_IsSendEmail = "User.IsSendEmail";

        /// <summary>
        /// 报警信息是否发送APP
        /// </summary>
        public const string User_IsSendApp = "User.IsSendApp";

        /// <summary>
        /// 接收报警类型
        /// </summary>
        public const string User_ReceiveAlarmType = "User.ReceiveAlarmType";

        /// <summary>
        /// 报警信息接收邮件列表
        /// </summary>
        public const string User_ReceiveEmails = "User.ReceiveEmails";

        /// <summary>
        /// 报警信息允许接收开始时间
        /// </summary>
        public const string User_ReceiveStartTime = "User.ReceiveStartTime";

        /// <summary>
        /// 报警信息允许接收结束时间
        /// </summary>
        public const string User_ReceiveEndTime = "User.ReceiveEndTime";

        /// <summary>
        /// 报警设防半径
        /// </summary>
        public const string User_FortifyRadius = "User.FortifyRadius";

        #endregion
    }
}
