namespace Shop.UserService.Domain.Common.Models.Base;

internal interface IValueObject
{
    bool Equals(object obj);
    IEnumerable<object> GetEqualityComparer();
}
