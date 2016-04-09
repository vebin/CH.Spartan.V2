using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;

namespace CH.Spartan.Repositories
{

    public interface ISpartanRepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {

    }

    public interface ISpartanRepositoryBase<TEntity> : ISpartanRepositoryBase<TEntity, int> where TEntity : class, IEntity<int>
    {

    }
}
