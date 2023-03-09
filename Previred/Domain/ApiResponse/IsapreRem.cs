using Newtonsoft.Json;

namespace Previred.Domain.ApiResponse;

internal class IsapreRem: ITotals
{
    [JsonProperty("rent_imp")] public int RentaImponible { get; set; }
    [JsonProperty("cot")] public int Cotizacion { get; set; }
    [JsonProperty("ley_18566")] public int Ley18566 { get; set; }
    [JsonProperty("cot_adc")] public int CotAdicional { get; set; }
    [JsonProperty("otro_desc_isap")] public int OtrosDescIsap { get; set; }
    [JsonProperty("cot_pag")] public int CotizacionAPagar { get; set; }
    [JsonProperty("cot_pac")] public string CotizacionPactada { get; set; }

    [JsonProperty("mov_personal")] public MovPersonal MovPersonal { get; set; }
    public int GetTotalPaidByEmployees()
    {
        return Cotizacion + Ley18566 + CotAdicional + OtrosDescIsap + OtrosDescIsap + CotizacionAPagar;
    }

    public int GetTotalPaidByEmployer()
    {
        return 0;
    }

    public int GetBonos() => 0;
    
    public int GetImponible() => RentaImponible;
}