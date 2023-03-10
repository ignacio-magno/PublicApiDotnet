namespace Sii.Domain.Fisco;

public class Iva : Base
{
    public Iva(int mount) : base(mount)
    {
    }

    public static implicit operator int(Iva iva) => iva.mount;
    public static explicit operator Iva(int total) => new(total);
}