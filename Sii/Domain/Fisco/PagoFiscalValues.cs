namespace Sii.Domain.Fisco;

public abstract class PagoFiscalValues
{
    public abstract Iva Iva { get; }
    public abstract Neto Neto { get; }
    public abstract Exento Exento { get; }
    public abstract Total Total { get; }

    public static double Dif<T>(PagoFiscalValues pagoFiscal, PagoFiscalValues newPagoFiscal)
    {
        if (typeof(T) == typeof(Iva))
        {
            return Math.Abs((pagoFiscal.Iva - newPagoFiscal.Iva));
        }

        if (typeof(T) == typeof(Neto))
        {
            return Math.Abs((pagoFiscal.Neto - newPagoFiscal.Neto));
        }

        if (typeof(T) == typeof(Total))
        {
            return Math.Abs((pagoFiscal.Total - newPagoFiscal.Total));
        }

        throw new Exception("unknow type");
    }
}