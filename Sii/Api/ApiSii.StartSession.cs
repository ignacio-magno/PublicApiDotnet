using System.Text;
using Newtonsoft.Json;
using Sii.Domain.ApiParse;

namespace Sii.Api;

internal partial class ApiSii
{
    private async Task<ApiSii> InitSession()
    {
        try
        {
            await StartSessionServer(new DateTime[] { new DateTime(2022, 1, 1) });
        }
        catch (Exception e)
        {
            throw new Exception("no se pudo iniciar sesión", e);
        }

        return this;
    }

    private async Task StartSessionServer(IEnumerable<DateTime> periodos)
    {
        var payload = new
        {
            username = Username,
            key = Password,
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

        if (summary == null) throw new Exception("no se pudo obtener el resumen de compra venta");
    }
}