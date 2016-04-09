using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using CH.Spartan.Authorization.Roles;
using CH.Spartan.Devices;
using CH.Spartan.DeviceTypes;
using CH.Spartan.MultiTenancy;
using CH.Spartan.Users;
using MySql.Data.Entity;
using CH.Spartan.Areas;
using CH.Spartan.DealRecords;
using CH.Spartan.Historys;
using CH.Spartan.Nodes;
using CH.Spartan.Reports;

namespace CH.Spartan.EntityFramework
{
    public class SpartanDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        /// <summary>
        /// 设备
        /// </summary>
        public IDbSet<Device> Devices { get; set; }

        /// <summary>
        /// 设备类型
        /// </summary>
        public IDbSet<DeviceType> DeviceTypes { get; set; }


        /// <summary>
        /// 区域
        /// </summary>
        public IDbSet<Area> Areas { get; set; }

        /// <summary>
        /// 交易记录
        /// </summary>
        public IDbSet<DealRecord> DealRecords { get; set; }

        /// <summary>
        /// 历史
        /// </summary>
        public IDbSet<History> Historys { get; set; }

        /// <summary>
        /// 节点
        /// </summary>
        public IDbSet<Node> Nodes { get; set; } 
        
        /// <summary>
        /// 日里程
        /// </summary>
        public IDbSet<MileageReportDay> MileageReportDays { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public SpartanDbContext()
            : base("Default")
        {
        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in SpartanDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of SpartanDbContext since ABP automatically handles it.
         */
        public SpartanDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public SpartanDbContext(DbConnection connection)
            : base(connection, true)
        {

        }

    }
}
