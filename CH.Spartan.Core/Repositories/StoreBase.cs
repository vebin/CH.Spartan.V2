using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.EntityFramework.Repositories;

namespace CH.Spartan.Repositories
{
    /// <summary>
    /// 存储
    /// </summary>
    /// <typeparam name="T">实体</typeparam>
    public abstract class StoreBase<T>: 
        ITransientDependency
        where T : Entity<int> 
    {
        /// <summary>
        /// 仓储
        /// </summary>
        protected IRepository<T> Repository {  get; }

        /// <summary>
        /// 工作单元
        /// </summary>
        protected IUnitOfWorkManager UnitOfWorkManager {  get; }

        /// <summary>
        /// 存储
        /// </summary>
        /// <param name="repository">仓储</param>
        /// <param name="unitOfWorkManager">工作单元</param>
        protected StoreBase(
            IRepository<T> repository, 
            IUnitOfWorkManager unitOfWorkManager)
        {
            Repository = repository;
            UnitOfWorkManager = unitOfWorkManager;
        }

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
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task CreateAsync(T entity)
        {
            await Repository.InsertAsync(entity);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task UpdateAsync(T entity)
        {
            await Repository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task DeleteAsync(T entity)
        {
            await Repository.DeleteAsync(entity.Id);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task DeleteByIdAsync(int id)
        {
            await Repository.DeleteAsync(id);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public virtual async Task DeleteByIdsAsync(IEnumerable<int> ids)
        {
            if (ids == null || !ids.Any())
            {
                return;
            }

            foreach (var id in ids)
            {
                await DeleteByIdAsync(id);
            }
        }

        /// <summary>
        /// 根据Id 查找
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<T> FindByIdAsync(int id)
        {
            return await Repository.FirstOrDefaultAsync(id);
        }
    }
}
