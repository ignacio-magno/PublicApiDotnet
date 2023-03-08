using Newtonsoft.Json;
using Previred.Domain.Entities;

namespace Previred.Domain.ApiResponse;

internal class AfpRem : ITotals
{
    [JsonProperty("rem_imp")] public int RemuneracionImponible { get; set; }
    [JsonProperty("cot_oblg")] public int CotizacionObligatoria { get; set; }
    [JsonProperty("cot_vol")] public int CotizacionVoluntaria { get; set; }
    [JsonProperty("dep_conv")] public int DepositoConvenido { get; set; }
    [JsonProperty("dep_cta_ahr")] public int DepCtaAhorro { get; set; }
    [JsonProperty("cot_afi")] public int CotizacionAfiliado { get; set; }
    [JsonProperty("cot_emp")] public int CotizacionEmpleador { get; set; }

    [JsonProperty("type_afp")] public Afp Afp { get; set; } = Afp.None;

    [JsonProperty("mov_personal")] public MovPersonal MovPersonal { get; set; }
    [JsonProperty("sis")] public int Sis { get; set; }

    public int GetTotalPaidByEmployees()
    {
        return
            CotizacionObligatoria +
            Sis +
            CotizacionVoluntaria +
            DepositoConvenido +
            DepCtaAhorro +
            CotizacionAfiliado;
    }

    public int GetTotalPaidByEmployer()
    {
        return CotizacionEmpleador;
    }

    public int GetBonos() => 0;
    public int GetImponible()
    {
        return RemuneracionImponible;
    }
}