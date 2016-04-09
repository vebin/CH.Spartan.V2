using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Configuration;
using Abp.Localization;

namespace CH.Spartan
{
    public class SpartanSettingProvider : SettingProvider
    {
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new[]
            {

                //通用
                new SettingDefinition(SpartanSettingKeys.General_Mail_IsEnable,GetDefaultSetting(SpartanSettingKeys.General_Mail_IsEnable,"true"),L("是否开启发送邮件")),
                new SettingDefinition(SpartanSettingKeys.General_Mail_Password,GetDefaultSetting(SpartanSettingKeys.General_Mail_Password,"Yuheng2015"),L("发送人邮箱密码")),
                new SettingDefinition(SpartanSettingKeys.General_Mail_Port,GetDefaultSetting(SpartanSettingKeys.General_Mail_Port,"25"),L("发送服务器端口号")),
                new SettingDefinition(SpartanSettingKeys.General_Mail_Send_Email,GetDefaultSetting(SpartanSettingKeys.General_Mail_Send_Email,"postmaster@fealance.com"),L("发送人邮箱")),
                new SettingDefinition(SpartanSettingKeys.General_Mail_Smtp,GetDefaultSetting(SpartanSettingKeys.General_Mail_Smtp,"smtp.mxhichina.com"),L("发送邮件服务器(Smtp)")),
                new SettingDefinition(SpartanSettingKeys.General_Mail_UserName,GetDefaultSetting(SpartanSettingKeys.General_Mail_UserName,"postmaster@fealance.com"),L("发送人邮箱名字")),
                new SettingDefinition(SpartanSettingKeys.General_Map_AMapAk,GetDefaultSetting(SpartanSettingKeys.General_Map_AMapAk,"250fed3f464be8847f9222509d2c6fab"),L("高德地图密钥")),
                new SettingDefinition(SpartanSettingKeys.General_Map_BaiduAk,GetDefaultSetting(SpartanSettingKeys.General_Map_BaiduAk,"slLbcEcljWxsOqywcSE7ejFd"),L("百度地图密钥")),
                new SettingDefinition(SpartanSettingKeys.General_Push_AppKey,GetDefaultSetting(SpartanSettingKeys.General_Push_AppKey,"fd6eca4a3d13df41cb248fc2"),L("推送AppKey")),
                new SettingDefinition(SpartanSettingKeys.General_Push_IsEnable,GetDefaultSetting(SpartanSettingKeys.General_Push_IsEnable,"true"),L("允许推送")),
                new SettingDefinition(SpartanSettingKeys.General_Push_Master_Secret,GetDefaultSetting(SpartanSettingKeys.General_Push_Master_Secret,"3852b355e7e43705ae76ae5c"),L("推送MasterSecret")),
                new SettingDefinition(SpartanSettingKeys.General_QQ_AppId,GetDefaultSetting(SpartanSettingKeys.General_QQ_AppId,"101255944"),L("QQ登录接入Id")),
                new SettingDefinition(SpartanSettingKeys.General_QQ_AppSecrett,GetDefaultSetting(SpartanSettingKeys.General_QQ_AppSecrett,"e06a5d2c5940ffe0fb86fb6b70ecca16"),L("QQ登录接入密钥")),
                new SettingDefinition(SpartanSettingKeys.General_WeChat_ApiUrl,GetDefaultSetting(SpartanSettingKeys.General_WeChat_ApiUrl,"https://api.weixin.qq.com/cgi-bin/"),L("微信接口地址")),
                new SettingDefinition(SpartanSettingKeys.General_WeChat_AppId,GetDefaultSetting(SpartanSettingKeys.General_WeChat_AppId,"wx9195c88be78faad0"),L("微信应用接入Id")),
                new SettingDefinition(SpartanSettingKeys.General_WeChat_AppSecret,GetDefaultSetting(SpartanSettingKeys.General_WeChat_AppSecret,"8a67db8d880fb4591186eb10ccb8e887"),L("微信应用接入密钥")),
                new SettingDefinition(SpartanSettingKeys.General_WeChat_Id,GetDefaultSetting(SpartanSettingKeys.General_WeChat_Id,"gh_d0effad52e42 "),L("微信应用账号")),
                new SettingDefinition(SpartanSettingKeys.General_WeChat_Token,GetDefaultSetting(SpartanSettingKeys.General_WeChat_Token,"fealance"),L("微信应用加密令牌")),
                new SettingDefinition(SpartanSettingKeys.General_WeiBo_AppId,GetDefaultSetting(SpartanSettingKeys.General_WeiBo_AppId,"1639955144"),L("微博登录接入Id")),
                new SettingDefinition(SpartanSettingKeys.General_WeiBo_AppSecret,GetDefaultSetting(SpartanSettingKeys.General_WeiBo_AppSecret,"f2206c86a2949eeb9df79222da1394a3"),L("微博登录接入密钥")),
                new SettingDefinition(SpartanSettingKeys.General_WeiXin_AppId,GetDefaultSetting(SpartanSettingKeys.General_WeiXin_AppId,"wxdcda5516be05d99f"),L("微信登录接入Id")),
                new SettingDefinition(SpartanSettingKeys.General_WeiXin_AppSecret,GetDefaultSetting(SpartanSettingKeys.General_WeiXin_AppSecret,"8c3e08ff4069fa8392811c83548fe7c1"),L("微信登录接入密钥")),
                //用户
                new SettingDefinition(SpartanSettingKeys.User_IsEnableAlarm,GetDefaultSetting(SpartanSettingKeys.User_IsEnableAlarm,"true"),L("报警是否开启")),
                new SettingDefinition(SpartanSettingKeys.User_AlarmSound,GetDefaultSetting(SpartanSettingKeys.User_AlarmSound,"default"),L("报警信息报警声音")),
                new SettingDefinition(SpartanSettingKeys.User_IsSendEmail,GetDefaultSetting(SpartanSettingKeys.User_IsSendEmail,"true"),L("报警信息是否发送邮件")),
                new SettingDefinition(SpartanSettingKeys.User_IsSendApp,GetDefaultSetting(SpartanSettingKeys.User_IsSendApp,"true"),L("报警信息是否发送APP")),
                new SettingDefinition(SpartanSettingKeys.User_ReceiveAlarmType,GetDefaultSetting(SpartanSettingKeys.User_ReceiveAlarmType,"all"),L("接收报警类型")),
                new SettingDefinition(SpartanSettingKeys.User_ReceiveEmails,GetDefaultSetting(SpartanSettingKeys.User_ReceiveEmails,""),L("报警信息接收邮件列表")),
                new SettingDefinition(SpartanSettingKeys.User_ReceiveStartTime,GetDefaultSetting(SpartanSettingKeys.User_ReceiveStartTime,"00:00:00"),L("报警信息允许接收开始时间")),
                new SettingDefinition(SpartanSettingKeys.User_ReceiveEndTime,GetDefaultSetting(SpartanSettingKeys.User_ReceiveEndTime,"23:59:59"),L("报警信息允许接收结束时间")),
                new SettingDefinition(SpartanSettingKeys.User_FortifyRadius,GetDefaultSetting(SpartanSettingKeys.User_FortifyRadius,"150"),L("报警设防半径")),
            };
        }

        private ILocalizableString L(string name)
        {
            return new LocalizableString(name, SpartanConsts.LocalizationSourceName);
        }

        private string GetDefaultSetting(string key, string defaultValue="")
        {
            return ConfigurationManager.AppSettings[key] ?? defaultValue;
        }
    }
}
