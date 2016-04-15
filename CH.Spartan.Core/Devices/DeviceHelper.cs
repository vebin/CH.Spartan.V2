
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH.Spartan.Devices
{
   public static class DeviceHelper
    {
        /// <summary>
        /// 5分钟内有数据上次上来 都属于在线状态
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public static bool IsOnline(Device device)
        {
            return device.GReceiveTime > DateTime.Now.AddMinutes(-5);
        }

        /// <summary>
        /// 是否过期
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public static bool IsExpire(Device device)
        {
            return device.BExpireTime > DateTime.Now;
        }
    }
}
