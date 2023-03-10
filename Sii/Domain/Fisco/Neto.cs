namespace Sii.Domain.Fisco;

public class Neto : Base
{
    public Neto(int mount) : base(mount)
    {
    }

    public static implicit operator int(Neto iva) => iva.mount;
    public static explicit operator Neto(int total) => new(total);
}