namespace Shop.UserService.Domain.UserAggregate.ValueObjects;

public class UserRoleId : ValueObject
{
    private static int _count;
    public int Id { get; set; }
    public UserRoleId(int id)
    {
        Id = id;
    }

    internal static UserRoleId CreateUnique()
    {
        return new UserRoleId(++_count);
    }

    public override IEnumerable<object> GetEqualityComparer()
    {
        yield return Id;
    }
}
