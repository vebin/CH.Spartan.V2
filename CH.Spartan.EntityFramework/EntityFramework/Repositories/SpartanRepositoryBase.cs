using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace CH.Spartan.EntityFramework.Repositories
{
   
    public abstract class SpartanRepositoryBase<TEntity, TPrimaryKey> : 
        EfRepositoryBase<SpartanDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected SpartanRepositoryBase(IDbContextProvider<SpartanDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class SpartanRepositoryBase<TEntity> :
        SpartanRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected SpartanRepositoryBase(IDbContextProvider<SpartanDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
