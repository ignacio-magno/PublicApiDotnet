using Newtonsoft.Json;

namespace Previred.Domain.ApiResponse;

internal class Septiembre18Rem : ITotals
{
    [JsonProperty("rem")] public int Remuneracion { get; set; }
    [JsonProperty("cot")] public int Cotizacion { get; set; }
    [JsonProperty("dias_trab")] public int DiasTrabajados { get; set; }
    [JsonProperty("carg_simp")] public int CargaSimple { get; set; }
    [JsonProperty("mont_asi_fam")] public int MontoAsiFamiliar { get; set; }
    [JsonProperty("cod_tram")] public string CodTramo { get; set; }
    [JsonProperty("pag_retr")] public int PagRetroactivo { get; set; }
    public MovPersonal? MovPersonal { get; set; }
    

    public int GetTotalPaidByEmployees()
    {
        return Cotizacion;
    }

    public int GetTotalPaidByEmployer()
    {
        return 0;
    }

    public int GetBonos() => 0;

    public int GetImponible() => Remuneracion;
}