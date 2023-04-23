using Shop.UserService.Application.Persistence.Base;
using Shop.UserService.Domain.UserAggregate;
using Shop.UserService.Domain.UserAggregate.ValueObjects;

namespace Shop.UserService.Application.Persistence.Users;

public interface IUserRepository : IRepository<UserId, User>
{
    User GetByEmail(string email);
    bool TryAddRole(UserId id, UserRoleId roleId, out User? user);
    bool TryRemoveRole(UserId id, UserRoleId roleId, out User? user);
}
