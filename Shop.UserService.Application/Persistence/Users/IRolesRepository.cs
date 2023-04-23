using Shop.UserService.Domain.UserAggregate.Entities;
using Shop.UserService.Domain.UserAggregate.ValueObjects;

namespace Shop.UserService.Application.Persistence.Users;

public interface IRolesRepository
{
    UserRole? GetRole(UserRoleId roleId);
}
