using Shop.UserService.Application.Persistence.Users;
using Shop.UserService.Domain.UserAggregate.Entities;
using Shop.UserService.Domain.UserAggregate.ValueObjects;

namespace Shop.UserService.Infrastructure.Persistence.Users;

public class RolesRepository : IRolesRepository
{
    private static readonly List<UserRole> _roles;
    static RolesRepository()
    {
        _roles = new()
        {
            UserRole.Create("Admin", "The administrator", "READ", "WRITE", "DELETE"),
            UserRole.Create("User", "A simple user", "READ", "WRITE"),
        };
    }
    public UserRole? GetRole(UserRoleId roleId)
    {
        var role = _roles.FirstOrDefault(x => x.Id == roleId);
        return role;
    }
}
