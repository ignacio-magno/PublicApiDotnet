namespace Sii.Domain.Fisco;

public class Exento : Base
{
    public Exento(int mount) : base(mount)
    {
    }


    public static implicit operator int(Exento iva) => iva.mount;
    public static explicit operator Exento(int total) => new(total);
}