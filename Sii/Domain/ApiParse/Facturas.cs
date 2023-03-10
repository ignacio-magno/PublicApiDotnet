using Newtonsoft.Json;
using Sii.Domain.Filters;

namespace Sii.Domain.ApiParse;

internal class Facturas
{
    [JsonProperty] private IEnumerable<DetailFactura> _facturas { get; set; }

    [JsonIgnore] public int Total => _facturas.Sum(j => j.Total);
    [JsonIgnore] public IEnumerable<string> ProveedoresRazonSocial => _facturas.Select(j => j.RazonSocial);
    [JsonIgnore] public IEnumerable<string> ProveedoresRut => _facturas.Select(j => j.RutProvider);


    public Facturas(IEnumerable<DetailFactura> facturas)
    {
        _facturas = facturas;
    }

    public int GetCount()
    {
        return _facturas.Count();
    }

    public IEnumerable<string> GetDetailProviders()
    {
        return _facturas.Select(j => $"{j.RutProvider} - {j.RazonSocial}");
    }

    public IEnumerable<DetailFactura> GetFacturas()
    {
        return _facturas;
    }

}