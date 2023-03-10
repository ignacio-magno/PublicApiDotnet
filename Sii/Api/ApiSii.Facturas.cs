using System.Text;
using Newtonsoft.Json;
using Sii.Domain.ApiParse;

namespace Sii.Api;

internal partial class ApiSii
{
    private readonly string FacturasEndPoint =
        "https://api.ignaciolp.cl/contabilidad/iva/details_facturas";

    public async Task<Facturas?> GetDetailsFacturasCompra(Resume compra)
    {
        return await GetDetailsFacturas(compra, true);
    }

    public async Task<Facturas?> GetDetailsFacturasVenta(Resume venta)
    {
        return await GetDetailsFacturas(venta, false);
    }

    private async Task<Facturas?> GetDetailsFacturas(Resume resume, bool isCompra)
    {
        if (!resume.IsLink) return default;

        var body = new
        {
            href = resume.KeyFile,
            typeSolicitud = isCompra ? 0 : 1,
            codeDocument = resume.ResumeCodigo
        };

        // TODO. delete this http client using singletton or factory 
        var result = await client.PostAsync(
            FacturasEndPoint,
            new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json"));

        var callbackApi = await result.Content.ReadAsStringAsync();
        var facturas = JsonConvert.DeserializeObject<List<DetailFactura>>(callbackApi);

        if (facturas == null) throw new Exception("no se pudo obtener las facturas detalladas");

        return new Facturas(facturas);
    }
}