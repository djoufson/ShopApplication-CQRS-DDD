using Shop.UserService.Domain.Common.Models;

namespace Shop.UserService.Domain.UserAggregate.ValueObjects;

public class UserId : ValueObject
{
    public Guid Id { get; set; }
    public UserId(Guid id)
    {
        Id = id;
    }

    public static UserId CreateUnique() => new (Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComparer()
    {
        yield return Id;
    }
}
