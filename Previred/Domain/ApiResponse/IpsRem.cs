using Newtonsoft.Json;

namespace Previred.Domain.ApiResponse;

internal class IpsRem: ITotals
{
    [JsonProperty("rem")] public int Remuneracion { get; set; }
    [JsonProperty("acc_trab")] public int AccidenteDelTrabajo { get; set; }
    [JsonProperty("dias_trab")] public int DiasTrabajados { get; set; }

    [JsonProperty("mov_personal")] public MovPersonal MovPersonal { get; set; }
    public int GetTotalPaidByEmployees()
    {
        return AccidenteDelTrabajo;
    }

    public int GetTotalPaidByEmployer()
    {
        return 0;
    }

    public int GetBonos() => 0;
}