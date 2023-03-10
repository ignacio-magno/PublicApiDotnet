using Sii.Domain.Filters;
using Sii.Domain.Fisco;

namespace Sii.Domain;

public class BookFacturas : PagoFiscalValues
{
    public List<Factura> Facturas;
    public int Count => Facturas.Count;

    public override Iva Iva => (Iva)Facturas.Sum(j => j.IvaRecuperable);
    public override Neto Neto => (Neto)Facturas.Sum(j => j.Neto);
    public override Exento Exento => (Exento)Facturas.Sum(j => j.Exento);
    public override Total Total => (Total)Facturas.Sum(j => j.Total);


    public BookFacturas(List<Factura> facturas)
    {
        Facturas = facturas;
    }

    public BookFacturas()
    {
        Facturas = new List<Factura>();
    }

    public void DeleteFirst()
    {
        Facturas.RemoveAt(0);
    }

    public void Add(Factura factura)
        => Facturas.Add(factura);

    public void Filter(FilterFacturas buildOnlyFalse)
    {
        Facturas = Facturas.Where(buildOnlyFalse.Filter).ToList();
    }

    public BookFacturas NewWithFacturasSelected(FilterFacturas filter)
    {
        var facturas = new BookFacturas();
        foreach (var factura in Facturas.Where(filter.Filter))
            facturas.Add(factura);
        return facturas;
    }
}