using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;
using CH.Spartan.Repositories;

namespace CH.Spartan.EntityFramework.Repositories
{
    public class SpartanRepositoryBase<TEntity, TPrimaryKey> : 
        EfRepositoryBase<SpartanDbContext, TEntity, TPrimaryKey>,
        ISpartanRepositoryBase<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected SpartanRepositoryBase(IDbContextProvider<SpartanDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public  class SpartanRepositoryBase<TEntity> :
        SpartanRepositoryBase<TEntity, int>,
        ISpartanRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected SpartanRepositoryBase(IDbContextProvider<SpartanDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
