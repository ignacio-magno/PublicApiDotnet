using Sii.Domain.ApiParse;

namespace Sii.Domain.Fisco;

/// <summary>
/// If use contructor with 1 field, the range of error is beetween 4 and 0, this is decimal values
/// </summary>
public class PagoFiscal : PagoFiscalValues
{
    public override Iva Iva { get; }
    public override Neto Neto { get; }
    public override Exento Exento { get; }
    public override Total Total { get; }

    public PagoFiscal(Iva iva)
    {
        Iva = iva;
        Total = new Total(iva * 119 / 19);
        Neto = new Neto(Total - iva);
        Exento = new Exento(0);
    }

    public PagoFiscal(Total total)
    {
        Iva = new Iva((int)Math.Round((decimal)(total * 19 / 119)));
        Neto = new Neto(total - Iva);
        Total = total;
        Exento = new Exento(0);
    }

    public PagoFiscal(int total)
    {
        Iva = new Iva((int)Math.Round((decimal)(total * 19 / 119)));
        Neto = new Neto(total - Iva);
        Total = (Total)total;
        Exento = new Exento(0);
    }

    public PagoFiscal(Neto mount)
    {
        Neto = mount;
        Iva = new Iva((int)Math.Round(Neto * 0.19));
        Total = new Total(Neto + Iva);
        Exento = new Exento(0);
    }

    public PagoFiscal(Exento exento, Neto neto, Iva iva, Total total)
    {
        Exento = exento;
        Neto = neto;
        Iva = iva;
        Total = total;
    }

    public PagoFiscal(int exento, int neto, int iva, int total)
    {
        Exento = (Exento)exento;
        Neto = (Neto)neto;
        Iva = (Iva)iva;
        Total = (Total)total;
    }

    internal PagoFiscal(Resume resume)
    {
        Exento = (Exento)resume.Exento;
        Neto = (Neto)resume.Neto;
        Iva = (Iva)resume.Iva;
        Total = (Total)resume.Total;
        //TODO: Implement others field of resume here.
    }
}