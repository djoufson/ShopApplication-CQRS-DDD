using Shop.UserService.Domain.Common.Models;
namespace Shop.UserService.Application.Persistence.Base;

public interface IRepository<TId, TEntity>
    where TId : ValueObject
    where TEntity : Entity<TId>
{
    TEntity Create(TEntity user);
    TEntity Update(TEntity user);
    void Delete(TId id);
    TEntity Get(TId id);
}
