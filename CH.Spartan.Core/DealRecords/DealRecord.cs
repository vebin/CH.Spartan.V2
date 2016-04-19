using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using CH.Spartan.Infrastructure;
using CH.Spartan.MultiTenancy;
using CH.Spartan.Users;

namespace CH.Spartan.DealRecords
{
    public class DealRecord : FullUserAndTenantEntity<User,Tenant>
    {

        /// <summary>
        /// 交易流水号
        /// </summary>
        [MaxLength(250)]
        public string No { get; set; }

        /// <summary>
        /// 交易外部编号
        /// </summary>
        [MaxLength(250)]
        public string OutNo { get; set; }

        /// <summary>
        /// 交易名称
        /// </summary>
        [MaxLength(250)]
        public string Name { get; set; }

        /// <summary>
        /// 交易备注
        /// </summary>
        [MaxLength(250)]
        public string Remark { get; set; }

        /// <summary>
        /// 交易类型
        /// </summary>
        public EnumDealRecordType Type { get; set; }

        /// <summary>
        /// 交易金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 交易成功
        /// </summary>
        public bool IsSucceed { get; set; }


        private static string GetNo(int tenantId, long userId)
        {
            return $"IDR{DateTime.Now.ToString("yyyyMMddHHmmss")}{tenantId}{userId}";
        }

        /// <summary>
        /// 创建一个 租户给客户安装设备 的交易记录
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="userId"></param>
        /// <param name="amount"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public static DealRecord CreateInstallDeviceDealRecord(int tenantId, long userId, decimal amount,string remark="")
        {
            return new DealRecord
            {
                No = GetNo(tenantId, userId),
                Name = "安装设备",
                TenantId = tenantId,
                UserId = userId,
                Type = EnumDealRecordType.InstallDevice,
                Amount = -amount,
                Remark = remark,
                IsSucceed = true,
            };
        }
    }
}
