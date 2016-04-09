using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Authorization.Users;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using CH.Spartan.DeviceTypes;
using CH.Spartan.MultiTenancy;
using CH.Spartan.Nodes;
using CH.Spartan.Users;

namespace CH.Spartan.Devices
{
    public class Device : FullUserAndTenantEntity<User,Tenant>
    {
        #region 基本信息
        /// <summary>
        /// 设备名字
        /// </summary>
        [Required, MaxLength(100)]
        public string BName { get; set; }

        /// <summary>
        /// 车牌号
        /// </summary>
        [Required, MaxLength(100)]
        public string BLicensePlate { get; set; }

        /// <summary>
        /// 设备图标类型
        /// </summary>
        [Required, MaxLength(50)]
        public string BIconType { get; set; }

        /// <summary>
        /// 设备类型Id
        /// </summary>
        public int BDeviceTypeId { get; set; }

        /// <summary>
        /// 设备号
        /// </summary>
        [Required, MaxLength(50)]
        public string BNo { get; set; }

        /// <summary>
        /// 设备唯一编码 
        /// 不同的设备编码生成规则不一样
        /// </summary>
        [Required, MaxLength(50)]
        public string BCode { get; set; }

        /// <summary>
        /// Sim号
        /// </summary>
        [Required, MaxLength(50)]
        public string BSimNo { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime? BExpireTime { get; set; }

        /// <summary>
        /// 所属节点Id
        /// </summary>
        public int BNodeId { get; set; }

        #endregion

        #region 设置信息

        /// <summary>
        /// 报警设置 超限速
        /// </summary>
        public int SLimitSpeed { get; set; }

        /// <summary>
        /// 报警设置 进出区域
        /// </summary>
        public bool SInOutArea { get; set; }

        #endregion

        #region 定位信息
        /// <summary>
        /// 方向 0-359,正北为0,顺时针
        /// </summary>
        public int GDirection { get; set; }

        /// <summary>
        /// 海拔高度,单位为米(m)
        /// </summary>
        public double GHeight { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public double GLatitude { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public double GLongitude { get; set; }

        /// <summary>
        /// 速度 (1/10)/km/h
        /// </summary>
        public double GSpeed { get; set; }

        /// <summary>
        /// GPS最后定位时间
        /// </summary>
        public DateTime GReportTime { get; set; }

        /// <summary>
        /// 设备最后通讯时间
        /// </summary>
        public DateTime GReceiveTime { get; set; }

        /// <summary>
        /// 是否已经定位 状态
        /// </summary>
        public bool GIsLocated { get; set; }
        #endregion

        #region 状态信息
        /// <summary>
        /// 状态 ACC
        /// </summary>
        public bool CIsAccOn { get; set; }

        /// <summary>
        /// 状态 电量
        /// </summary>
        public int CPower { get; set; }

        /// <summary>
        /// 状态 是否继电器启用
        /// </summary>
        public bool CIsRelayEnable { get; set; }

        /// <summary>
        /// 状态 电器启用时间
        /// </summary>
        public DateTime? CRelayBreakTime { get; set; }

        /// <summary>
        /// 状态 是否外接电源断开
        /// </summary>
        public bool CIsMainPowerBreak { get; set; }

        /// <summary>
        /// 状态 外接电源断开时间
        /// </summary>
        public DateTime? CMainPowerBreakTime { get; set; }

        /// <summary>
        /// 状态 外接电源断开最后一次报警时间
        /// </summary>
        public DateTime? CMainPowerBreakLastAlarmTime { get; set; }

        /// <summary>
        /// 状态 是否SOS求助
        /// </summary>
        public bool CIsSos { get; set; }

        /// <summary>
        /// 状态 超速时间
        /// </summary>
        public DateTime? COverSpeedTime { get; set; }

        /// <summary>
        /// 状态 超速最后报警时间
        /// </summary>
        public DateTime? COverSpeedLastAlarmTime { get; set; }

        /// <summary>
        /// 状态 启动时间
        /// </summary>
        public DateTime? CStartupTime { get; set; }

        /// <summary>
        /// 状态 启动最后报警时间
        /// </summary>
        public DateTime? CStartupLastAlarmTime { get; set; }

        /// <summary>
        /// 状态 拥有速度时间
        /// </summary>
        public DateTime? CLastHaveSpeedTime { get; set; }

        /// <summary>
        /// 状态 拥有速度最后报警时间
        /// </summary>
        public DateTime? CLastHaveSpeedLastAlarmTime { get; set; }

        /// <summary>
        /// 状态 进入区域列表
        /// </summary>
        [MaxLength(500)]
        public string CInAreaList { get; set; }

        /// <summary>
        /// 状态 是否处于设防状态
        /// </summary>
        public bool CIsFortify { get; set; }

        /// <summary>
        /// 状态 设防时的经纬度
        /// </summary>
        [MaxLength(100)]
        public string CFortifyLatLng { get; set; }

        /// <summary>
        /// 状态 离开设防区域时间
        /// </summary>
        public DateTime? CLeaveFortifyAreaTime { get; set; }

        /// <summary>
        /// 状态 离开设防区域最后报警时间
        /// </summary>
        public DateTime? CLeaveFortifyAreaLastAlarmTime { get; set; }


        /// <summary>
        /// 状态 是否脱落
        /// </summary>
        public bool CIsDropOff { get; set; }

        /// <summary>
        /// 状态 脱落时间
        /// </summary>
        public DateTime? CDropOffTime { get; set; }

        /// <summary>
        /// 状态 脱落最后报警时间
        /// </summary>
        public DateTime? CDropOffLastAlarmTime { get; set; }

        /// <summary>
        /// 状态 是否震动
        /// </summary>
        public bool CIsShake { get; set; }

        /// <summary>
        /// 状态 震动时间
        /// </summary>
        public DateTime? CShakeTime { get; set; }

        /// <summary>
        /// 状态 是否低电
        /// </summary>
        public bool CIsLowBattery { get; set; }

        /// <summary>
        /// 状态 低电时间
        /// </summary>
        public DateTime? CLowBatteryTime { get; set; }

        /// <summary>
        /// 状态 低电最后报警时间
        /// </summary>
        public DateTime? CLowBatteryLastAlarmTime { get; set; }

        /// <summary>
        /// 状态 是否进入盲区
        /// </summary>
        public bool CIsInBlindArea { get; set; }

        /// <summary>
        /// 状态 进入盲区时间
        /// </summary>
        public DateTime? CInBlindAreaTime { get; set; }

        /// <summary>
        /// 状态 进入盲区最后报警时间
        /// </summary>
        public DateTime? CInBlindAreaLastAlarmTime { get; set; }

        #endregion

        #region 导航属性

        /// <summary>
        /// 设备类型
        /// </summary>
        [ForeignKey("BDeviceTypeId")]
        public virtual DeviceType DeviceType { get; set; }

        /// <summary>
        /// 所属节点
        /// </summary>
        [ForeignKey("BNodeId")]
        public virtual Node Node { get; set; }

        #endregion
    }
}
