namespace Shop.Common.Domain_Layer.Models.Base;

internal interface IValueObject
{
    bool Equals(object obj);
    IEnumerable<object> GetEqualityComparer();
}
