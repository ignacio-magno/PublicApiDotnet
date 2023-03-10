using Sii.Api;
using Sii.Domain.ApiParse;

namespace Sii;

public class SiiClient
{
    ApiSii _apiSii;

    public SiiClient(HttpClient httpClient, string apiToken, string userName, string password)
    {
        _apiSii = new ApiSii(httpClient, apiToken, userName, password);
    }

    // ! alway make error if build compraventa with this method, because many documents require facturas,
    // and this method not return facturas, only summary.
    // ¿is neccesary to build compraventa with this method?
    public async Task<CompraVenta> GetSummaryCompraVenta(int month, int year)
    {
        var summary = await _apiSii.GetSummaryCompraVenta(new DateTime[]
        {
            new DateTime(year, month, 1)
        });
        return new CompraVenta(summary);
    }

    public async Task<CompraVenta> GetSummaryCompraVentaWithFacturas(int month, int year)
    {
        var summary = await _apiSii.GetSummaryCompraVenta(new DateTime[]
        {
            new DateTime(year, month, 1)
        });

        var tasks = new List<Task>();

        tasks.Add(summary.Venta.ForEachResumeAsync(SetFacturasVenta));
        tasks.Add(summary.Compra.ForEachResumeAsync(SetFacturasCompra));

        await Task.WhenAll(tasks);

        return new CompraVenta(summary);
    }


    private async Task SetFacturasCompra(Resume compra)
    {
        var facturas = await _apiSii.GetDetailsFacturasCompra(compra);
        compra.Facturas = facturas;
    }

    private async Task SetFacturasVenta(Resume venta)
    {
        var facturas = await _apiSii.GetDetailsFacturasVenta(venta);
        venta.Facturas = facturas;
    }
}