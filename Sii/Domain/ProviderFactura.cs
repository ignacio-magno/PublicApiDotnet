using Sii.Domain.Filters;
using Sii.Domain.Fisco;

namespace Sii.Domain;

public class ProviderFactura
{
    public string Rut { get; }
    public string RazonSocial { get; }

    public ProviderFactura(string facturaRutProvider, string facturaRazonSocial)
    {
        Rut = facturaRutProvider;
        RazonSocial = facturaRazonSocial;
    }

    public Factura MakeFactura(int total)
    {
        var pagoFiscal = new PagoFiscal((Total)total);
        var factura = new Factura.Builder().WithRazonSocial(RazonSocial)
            .WithRutProveedor(Rut)
            .WithFolio(10)
            .WithFechaEmision(DateTime.Now)
            .WithExento(pagoFiscal.Exento)
            .WithNeto(pagoFiscal.Neto)
            .WithIvaRecuperable(pagoFiscal.Iva)
            .WithTotal(pagoFiscal.Total)
            .Build();
        return factura;
    }

    public FilterFacturas MakeFilterByRut() => FilterFacturas.Builder.New().ByRut(Rut).BuildOnlyFalse();
}