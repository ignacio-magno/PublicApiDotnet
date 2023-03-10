namespace Sii.Domain.Fisco;

public abstract class Base : IEquatable<Base>
{
    protected int mount;
    public readonly static int rangeError = 2;

    protected Base(int mount)
    {
        this.mount = mount;
    }

    public bool Equals(Base? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Math.Abs(mount - other.mount) < rangeError;
    }

    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj) || obj is Base other && Equals(other);
    }

    public override int GetHashCode()
    {
        return mount;
    }

    public static bool operator ==(Base? left, Base? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Base? left, Base? right)
    {
        return !Equals(left, right);
    }
}