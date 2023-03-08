using Newtonsoft.Json;

namespace Previred.Domain.ApiResponse;

internal class SeguridadRem : ITotals
{
    [JsonProperty("remuneration")] public int Remuneracion { get; set; }
    [JsonProperty("cotizacion")] public int Cotizacion { get; set; }

    [JsonProperty("mov_personal")] public MovPersonal MovPersonal { get; set; }

    public int GetTotalPaidByEmployees()
    {
        return Cotizacion;
    }

    public int GetTotalPaidByEmployer()
    {
        return 0;
    }

    public int GetBonos() => 0;
}