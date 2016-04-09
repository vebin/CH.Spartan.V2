using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace CH.Spartan.Devices.Dto
{
    [AutoMap(typeof(Device))]
    public class UpdateDeviceDto :EntityDto, IDoubleWayDto
       {
        /// <summary>
        /// 设备名字
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string BName { get; set; }

        /// <summary>
        /// 车牌号
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string BLicensePlate { get; set; }

        /// <summary>
        /// 设备图标类型
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string BIconType { get; set; }

        /// <summary>
        /// 设备类型Id
        /// </summary>
        public int BDeviceTypeId { get; set; }

        /// <summary>
        /// 设备号
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string BNo { get; set; }

        /// <summary>
        /// 设备唯一编码不同的设备编码生成规则不一样
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string BCode { get; set; }

        /// <summary>
        /// Sim号
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string BSimNo { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime? BExpireTime { get; set; }

        /// <summary>
        /// 所属节点Id
        /// </summary>
        public int BNodeId { get; set; }

        /// <summary>
        /// 报警设置超限速
        /// </summary>
        public int SLimitSpeed { get; set; }

        /// <summary>
        /// 报警设置进出区域
        /// </summary>
        public bool SInOutArea { get; set; }

        /// <summary>
        /// 方向0-359,正北为0,顺时针
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
        /// 速度(1/10)/km/h
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
        /// 是否已经定位状态
        /// </summary>
        public bool GIsLocated { get; set; }

        /// <summary>
        /// 状态ACC
        /// </summary>
        public bool CIsAccOn { get; set; }

        /// <summary>
        /// 状态电量
        /// </summary>
        public int CPower { get; set; }

        /// <summary>
        /// 状态是否继电器启用
        /// </summary>
        public bool CIsRelayEnable { get; set; }

        /// <summary>
        /// 状态电器启用时间
        /// </summary>
        public DateTime? CRelayBreakTime { get; set; }

        /// <summary>
        /// 状态是否外接电源断开
        /// </summary>
        public bool CIsMainPowerBreak { get; set; }

        /// <summary>
        /// 状态外接电源断开时间
        /// </summary>
        public DateTime? CMainPowerBreakTime { get; set; }

        /// <summary>
        /// 状态外接电源断开最后一次报警时间
        /// </summary>
        public DateTime? CMainPowerBreakLastAlarmTime { get; set; }

        /// <summary>
        /// 状态是否SOS求助
        /// </summary>
        public bool CIsSos { get; set; }

        /// <summary>
        /// 状态超速时间
        /// </summary>
        public DateTime? COverSpeedTime { get; set; }

        /// <summary>
        /// 状态超速最后报警时间
        /// </summary>
        public DateTime? COverSpeedLastAlarmTime { get; set; }

        /// <summary>
        /// 状态启动时间
        /// </summary>
        public DateTime? CStartupTime { get; set; }

        /// <summary>
        /// 状态启动最后报警时间
        /// </summary>
        public DateTime? CStartupLastAlarmTime { get; set; }

        /// <summary>
        /// 状态拥有速度时间
        /// </summary>
        public DateTime? CLastHaveSpeedTime { get; set; }

        /// <summary>
        /// 状态拥有速度最后报警时间
        /// </summary>
        public DateTime? CLastHaveSpeedLastAlarmTime { get; set; }

        /// <summary>
        /// 状态进入区域列表
        /// </summary>
        [MaxLength(500)]
        public string CInAreaList { get; set; }

        /// <summary>
        /// 状态是否处于设防状态
        /// </summary>
        public bool CIsFortify { get; set; }

        /// <summary>
        /// 状态设防时的经纬度
        /// </summary>
        [MaxLength(100)]
        public string CFortifyLatLng { get; set; }

        /// <summary>
        /// 状态离开设防区域时间
        /// </summary>
        public DateTime? CLeaveFortifyAreaTime { get; set; }

        /// <summary>
        /// 状态离开设防区域最后报警时间
        /// </summary>
        public DateTime? CLeaveFortifyAreaLastAlarmTime { get; set; }

        /// <summary>
        /// 状态是否脱落
        /// </summary>
        public bool CIsDropOff { get; set; }

        /// <summary>
        /// 状态脱落时间
        /// </summary>
        public DateTime? CDropOffTime { get; set; }

        /// <summary>
        /// 状态脱落最后报警时间
        /// </summary>
        public DateTime? CDropOffLastAlarmTime { get; set; }

        /// <summary>
        /// 状态是否震动
        /// </summary>
        public bool CIsShake { get; set; }

        /// <summary>
        /// 状态震动时间
        /// </summary>
        public DateTime? CShakeTime { get; set; }

        /// <summary>
        /// 状态是否低电
        /// </summary>
        public bool CIsLowBattery { get; set; }

        /// <summary>
        /// 状态低电时间
        /// </summary>
        public DateTime? CLowBatteryTime { get; set; }

        /// <summary>
        /// 状态低电最后报警时间
        /// </summary>
        public DateTime? CLowBatteryLastAlarmTime { get; set; }

        /// <summary>
        /// 状态是否进入盲区
        /// </summary>
        public bool CIsInBlindArea { get; set; }

        /// <summary>
        /// 状态进入盲区时间
        /// </summary>
        public DateTime? CInBlindAreaTime { get; set; }

        /// <summary>
        /// 状态进入盲区最后报警时间
        /// </summary>
        public DateTime? CInBlindAreaLastAlarmTime { get; set; }

        /// <summary>
        /// 所属用户Id
        /// </summary>
        public long UserId { get; set; }

    }

    public class UpdateDeviceInput : IInputDto
    {
        public UpdateDeviceDto Device { get; set; }
    }

    public class UpdateDeviceOutput : IOutputDto
    {
        public UpdateDeviceOutput(UpdateDeviceDto device)
        {
            Device = device;
        }

        public UpdateDeviceDto Device { get; set; }
    }
}
