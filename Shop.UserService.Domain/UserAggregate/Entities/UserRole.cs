namespace Shop.UserService.Domain.UserAggregate.Entities;

public sealed class UserRole : Entity<UserRoleId>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<string> Priviledges { get; set; }
    private UserRole(
        UserRoleId id,
        string name,
        string description,
        List<string> priviledges) : base(id)
    {
        Name = name;
        Description = description;
        Priviledges = priviledges;
    }

    public static UserRole Create(
        string name,
        string description,
        IEnumerable<string> priviledges)
    {
        return new UserRole(
            UserRoleId.CreateUnique(),
            name,
            description,
            priviledges.ToList());
    }

    public static UserRole Create(
        string name,
        string description,
        params string[] priviledges)
    {
        return new UserRole(
            UserRoleId.CreateUnique(),
            name,
            description,
            priviledges.ToList());
    }
}
