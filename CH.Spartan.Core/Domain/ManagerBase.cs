using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Configuration;
using Abp.Dependency;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Domain.Uow;
using Abp.EntityFramework.Repositories;
using Abp.Localization;
using Abp.Runtime.Caching;
using Abp.Runtime.Session;

namespace CH.Spartan.Domain
{
    /// <summary>
    /// 领域服务
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ManagerBase<T>
        : IDomainService
        where T : Entity<int>
    {
        
        /// <summary>
        /// 当前会话
        /// </summary>
        public IAbpSession AbpSession { get; set; }

        /// <summary>
        /// 本地语言
        /// </summary>
        public ILocalizationManager LocalizationManager { get; set; }

        /// <summary>
        /// 设置管理
        /// </summary>
        public ISettingManager SettingManager { get; set; }

        /// <summary>
        /// 缓存
        /// </summary>
        public ICacheManager CacheManager { get; set; }

        /// <summary>
        /// Ioc
        /// </summary>
        public IIocResolver IocResolver { get; set; }

        /// <summary>
        /// 工作单元
        /// </summary>
        public IUnitOfWorkManager UnitOfWorkManager { get; set; }

        /// <summary>
        /// 存储
        /// </summary>
        public IRepository<T> Repository { get; set; }

        /// <summary>
        /// 数据库
        /// </summary>
        protected virtual Database Database => (Repository as IDataBase<T>)?.Database;

        /// <summary>
        /// 表
        /// </summary>
        protected virtual DbSet<T> Table => (Repository as IDataBase<T>)?.Table;

        /// <summary>
        /// 查询
        /// </summary>
        public virtual IQueryable<T> Query => Repository.GetAll();

        /// <summary>
        /// 领域服务
        /// </summary>
        /// <param name="repository">仓储</param>
        /// <param name="settingManager">设置</param>
        /// <param name="cacheManager">缓存</param>
        /// <param name="iocResolver">Ioc</param>
        /// <param name="unitOfWorkManager">工作单元</param>
        protected ManagerBase(
            IRepository<T> repository,
            ISettingManager settingManager,
            ICacheManager cacheManager,
            IIocResolver iocResolver,
            IUnitOfWorkManager unitOfWorkManager
            )
        {
            AbpSession = NullAbpSession.Instance;
            LocalizationManager = NullLocalizationManager.Instance;
            SettingManager = settingManager;
            CacheManager = cacheManager;
            IocResolver = iocResolver;
            UnitOfWorkManager = unitOfWorkManager;
            Repository = repository;
        }

        public async Task DeleteByIdsAsync(IEnumerable<int> ids)
        {
            foreach (var id in ids)
            {
               await Repository.DeleteAsync(id);
            }
        }
    }
}
