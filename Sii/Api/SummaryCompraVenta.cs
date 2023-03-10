using System.Text;
using Newtonsoft.Json;
using Sii.Domain.ApiParse;

namespace Sii.Api;

internal partial class ApiSii
{
    public async Task<SummaryCompraVenta> GetSummaryCompraVenta(IEnumerable<DateTime> periodos)
    {
        if (periodos.Count() == 0) throw new ArgumentNullException(nameof(periodos));
        var payload = new
        {
            username = Username,
            key = "asdf",
            metadata = periodos.Select(j =>
            {
                return new
                {
                    period = new
                    {
                        month = j.Month,
                        year = j.Year
                    }
                };
            })
        };

        var response = await client.PostAsync(UrlSummaryIvaWithPersistence,
            new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json"));

        if (!response.IsSuccessStatusCode) throw new Exception(await response.Content.ReadAsStringAsync());

        var content = await response.Content.ReadAsStringAsync();

        var summary = JsonConvert.DeserializeObject<SummaryCompraVenta>(content);

        if (summary == null) throw new Exception("no se pudo obtener el resumen de compra venta, " + content);

        return summary;
    }
}