using CH.Spartan.Commons;

namespace CH.Spartan
{
    #region 常量
    public class SpartanConsts
    {
        public const string LocalizationSourceName = "Spartan";
        public const int DefaultMaxResultCount = 10;
        public const string DefaultSorting = "Id DESC";
    }
    #endregion


    #region 枚举
    public enum EnumProtocol
    {
        [EnumDisplayName("部标T808")]
        T808 = 20,
        [EnumDisplayName("铁甲骑兵D10")]
        D10 = 30,
        [EnumDisplayName("康凯斯")]
        Kks = 40,
        [EnumDisplayName("天琴(天禾)协议")]
        Tq = 50
    }

    public enum EnumCodeCreateRule
    {
        [EnumDisplayName("手机号0前缀")]
        SimNoWithZeroPrefix = 5,
        [EnumDisplayName("Gps设备号")]
        DeviceGpsNo = 3,
        [EnumDisplayName("Gps设备号0前缀")]
        DeviceGpsNoWithZeroPrefix = 2,
        [EnumDisplayName("康凯斯")]
        Kks = 4
    }
    #endregion
}