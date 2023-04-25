using Shop.UserService.Application.Persistence.Users;
using Shop.UserService.Domain.UserAggregate;
using Shop.UserService.Domain.UserAggregate.Entities;
using Shop.UserService.Domain.UserAggregate.ValueObjects;

namespace Shop.UserService.Infrastructure.Persistence.Users;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();
    private readonly IRolesRepository _roles;

    public UserRepository(IRolesRepository roles)
    {
        _roles = roles;
    }

    public User Create(User user)
    {
        // If the roles are not set, we by defaul set them to simple user
        if (user.UserRoles is null || !user.UserRoles.Any())
            user.UserRoles = new List<UserRole>() 
            { 
                _roles.GetRole(new UserRoleId(2))! 
            };

        _users.Add(user);
        return user;
    }

    public void Delete(UserId id)
    {
        var user = _users.FirstOrDefault(x => x.Id == id);
        _users.Remove(user!);
    }

    public User Get(UserId id)
    {
        var user = _users.FirstOrDefault(x => x.Id == id);
        return user!;
    }

    public User GetByEmail(string email)
    {
        var user = _users.FirstOrDefault(x => x.Email == email);
        return user!;
    }

    public bool TryAddRole(UserId id, UserRoleId roleId, out User? user)
    {
        var role = _roles.GetRole(roleId);
        if (role is null)
        {
            user = null;
            return false;
        }
        user = Get(id);
        if (user is null)
            return true;

        user.UserRoles.Add(role);
        return true;
    }

    public bool TryRemoveRole(UserId id, UserRoleId roleId, out User? user)
    {
        var role = _roles.GetRole(roleId);
        if (role is null)
        {
            user = null;
            return false;
        }
        user = Get(id);
        if (user is null)
            return true;

        return user.UserRoles.Remove(role);
    }

    public User Update(User user)
    {
        if (_users.Select(u => u.Id)
            .Contains(user.Id))
        {
            // TODO: Make the update logic
        }
        else
        {
            _users.Add(user);
        }
        return user;
    }
}
