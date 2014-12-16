using Abp.Domain.Entities;
using Abp.EntityFramework.Repositories;

namespace TaxiApp.EntityFramework.Repositories
{
    public abstract class TaxiAppRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<TaxiAppDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
    }

    public abstract class TaxiAppRepositoryBase<TEntity> : TaxiAppRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {

    }
}
