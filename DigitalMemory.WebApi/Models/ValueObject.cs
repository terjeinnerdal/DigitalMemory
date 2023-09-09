namespace DigitalMemory.WebApi.Models;

[Serializable]
public abstract class ValueObject2 : IComparable, IComparable<ValueObject2>
{
    private int? _cachedHashCode;

    protected abstract IEnumerable<IComparable> GetEqualityComponents();

    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;

        if (GetUnproxiedType(this) != GetUnproxiedType(obj))
            return false;

        var valueObject = (ValueObject2)obj;

        return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        if (!_cachedHashCode.HasValue)
        {
            _cachedHashCode = GetEqualityComponents()
                .Aggregate(1, (current, obj) =>
                {
                    unchecked
                    {
                        return (current * 23) + (obj?.GetHashCode() ?? 0);
                    }
                });
        }

        return _cachedHashCode.Value;
    }


    public virtual int CompareTo(ValueObject2? other)
    {
        if (other is null)
            return 1;

        if (ReferenceEquals(this, other))
            return 0;

        Type thisType = GetUnproxiedType(this);
        Type otherType = GetUnproxiedType(other);
        if (thisType != otherType)
            return string.Compare($"{thisType}", $"{otherType}", StringComparison.Ordinal);

        return
            GetEqualityComponents().Zip(
                other.GetEqualityComponents(),
                (left, right) =>
                    left?.CompareTo(right) ?? (right is null ? 0 : -1))
            .FirstOrDefault(cmp => cmp != 0);
    }

    public virtual int CompareTo(object? other)
    {
        return CompareTo(other as ValueObject2);
    }

    public static bool operator ==(ValueObject2 a, ValueObject2 b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(ValueObject2 a, ValueObject2 b)
    {
        return !(a == b);
    }

    internal static Type GetUnproxiedType(object obj)
    {
        const string EFCoreProxyPrefix = "Castle.Proxies.";
        const string NHibernateProxyPostfix = "Proxy";

        Type type = obj.GetType();
        string typeString = type.ToString();

        if (typeString.Contains(EFCoreProxyPrefix) || typeString.EndsWith(NHibernateProxyPostfix))
            return type.BaseType;

        return type;
    }
}

public abstract class ValueObject
{
    protected static bool EqualOperator(ValueObject left, ValueObject right)
    {
        if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
        {
            return false;
        }
        return ReferenceEquals(left, null) || left.Equals(right);
    }

    protected static bool NotEqualOperator(ValueObject left, ValueObject right)
    {
        return !EqualOperator(left, right);
    }

    protected abstract IEnumerable<object> GetEqualityComponents();

    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != GetType())
        {
            return false;
        }

        var other = (ValueObject)obj;

        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x != null ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
    }

    public ValueObject GetCopy()
    {
        return MemberwiseClone() as ValueObject;
    }
}
