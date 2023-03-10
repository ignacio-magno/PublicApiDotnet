namespace Sii.Domain.Fisco;

public class Total : Base
{
    public Total(int mount) : base(mount)
    {
    }

    public static implicit operator int(Total total) => total.mount;
    public static explicit operator Total(int total) => new(total);
}