using Shop.Common.Domain_Layer.Models.Base;

namespace Shop.Common.Application_Layer.Persistence.Base;

public interface IRepository<TId, TEntity>
    where TId : ValueObject
    where TEntity : Entity<TId>
{
    TEntity? Create(TEntity entity);
    TEntity? Update(TEntity entity);
    void Delete(TId id);
    TEntity? Get(TId id);
}
