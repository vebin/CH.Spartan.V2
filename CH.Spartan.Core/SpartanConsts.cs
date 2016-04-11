using System;
using CH.Spartan.Commons;

namespace CH.Spartan
{
    #region 常量
    public class SpartanConsts
    {
        public const string LocalizationSourceName = "Spartan";
        public const int DefaultMaxResultCount = 10;
        public const string DefaultSorting = "Id DESC";
        public const string DefaultPassword = "123456";
        public const string DefaultAnimate = "animated lightSpeedIn";

    }
    #endregion

    #region 枚举

    public enum EnumDealRecordType
    {
        [EnumDisplayName("充值")]
        Deposit = 1,
        [EnumDisplayName("安装设备")]
        InstallDevice = 2
    }
    public enum EnumAreaType
    {
        [EnumDisplayName("矩形")]
        Polygon = 1,
        [EnumDisplayName("圆圈")]
        Circle = 2
    }

    public enum EnumCodeCreateRule
    {
        [EnumDisplayName("设备号")]
        No=0
    }

    [Flags]
    public enum EnumAlarmType
    {
        [EnumDisplayName("离线报警")]
        OffLine =1,
        [EnumDisplayName("断电报警")]
        MainPowerBreak = 2,
        [EnumDisplayName("SOS求救")]
        Sos = 4,
        [EnumDisplayName("超速报警")]
        OverSpeed = 8,
        [EnumDisplayName("进入区域")]
        InArea = 16,
        [EnumDisplayName("离开设防")]
        Fortify = 32,
        [EnumDisplayName("脱落报警")]
        DropOff = 64,
        [EnumDisplayName("震动报警")]
        Shake = 128,
        [EnumDisplayName("低电报警")]
        LowBattery = 256,
        [EnumDisplayName("进入盲区")]
        InBlindArea = 512,
        [EnumDisplayName("离开盲区")]
        OutBlindArea = 1024,
        [EnumDisplayName("启动报警")]
        Startup = 2048
    }

    #endregion
}