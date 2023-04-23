namespace Shop.Common.Domain_Layer.Models.Base;

public abstract class ValueObject : IValueObject, IEquatable<ValueObject>
{
    public static bool operator ==(ValueObject left, ValueObject right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(ValueObject left, ValueObject right)
    {
        return !left.Equals(right);
    }
    public bool Equals(ValueObject? other)
    {
        if (other is null) return false;

        var selfComparer = GetEqualityComparer();
        var otherComparer = other.GetEqualityComparer();

        var notSameLenght = selfComparer.Count() != otherComparer.Count();
        if(notSameLenght) return false;

        var equals = true;
        for(int i = 0; i < selfComparer.Count(); i++)
        {
            var value1 = selfComparer.ElementAt(i);
            var value2 = otherComparer.ElementAt(i);
            equals = value1.Equals(value2);
            if(!equals) break;
        }

        return equals;
    }

    public abstract IEnumerable<object> GetEqualityComparer();

    public override bool Equals(object obj)
    {
        if(obj is ValueObject other)
        {
            return Equals(other);
        }
        return false;
    }

    public override int GetHashCode()
    {
        return GetEqualityComparer().GetHashCode();
    }

    public override string ToString()
    {
        foreach (var criteria in GetEqualityComparer())
            return criteria?.ToString() ?? string.Empty;

        return string.Empty;
    }
}
