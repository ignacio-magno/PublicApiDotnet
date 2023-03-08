using Newtonsoft.Json;

namespace Previred.Domain.ApiResponse;

internal class FonasaRem: ITotals
{
    [JsonProperty("dias_trab")] public int DiasTrabajados { get; set; }
    [JsonProperty("ent_prev")] public string EntidadPrevisional { get; set; }
    [JsonProperty("rem")] public int Remuneracion { get; set; }
    [JsonProperty("cot")] public int Cotizacion { get; set; }

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