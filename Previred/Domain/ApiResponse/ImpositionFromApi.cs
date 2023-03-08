using Newtonsoft.Json;

namespace Previred.Domain.ApiResponse;

internal class ImpositionFromApi
{
    [JsonProperty("rut_business")] public string RutBusiness { get; set; }
    [JsonProperty("month")] public string Month { get; set; }
    [JsonProperty("year")] public int Year { get; set; }
    [JsonProperty("values")] public List<ValuesCotizacionEmployee> ValuesCotizacionEmployee { get; set; }
}