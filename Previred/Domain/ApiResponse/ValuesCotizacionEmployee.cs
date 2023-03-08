using Newtonsoft.Json;

namespace Previred.Domain.ApiResponse;

internal class ValuesCotizacionEmployee
{
    public int IdEmployee { get; set; }

    [JsonProperty("rut")] public string Rut { get; set; }
    [JsonProperty("name")] public string Name { get; set; }
    [JsonProperty("afp")] public List<AfpRem>? AfpRem { get; set; } = null;
    [JsonProperty("fonasa")] public List<FonasaRem>? FonasaRem { get; set; } = null;
    [JsonProperty("ips")] public List<IpsRem>? IpsRem { get; set; } = null;
    [JsonProperty("banmedica")] public List<IsapreRem>? BanmedicaRem { get; set; } = null;
    [JsonProperty("sept18")] public List<Septiembre18Rem>? Septiembre18Rem { get; set; } = null;

    [JsonProperty("credito_18_septiembre")]
    public List<Credito18Septiembre>? Credito18Septiembre { get; set; } = null;

    [JsonProperty("cchc")] public List<SeguridadRem>? CchcRem { get; set; } = null;
    [JsonProperty("isl")] public List<SeguridadRem>? IslRem { get; set; } = null;
    [JsonProperty("cruz_blanca")] public List<IsapreRem>? CruzBlancaRem { get; set; } = null;
    [JsonProperty("mas_vida")] public List<IsapreRem>? MasVidaRem { get; set; } = null;

    // TODO: make this dynamic, if possible
    public IEnumerable<ITotals> GetTotalsList()
    {
        var list = new List<ITotals>();

        if (AfpRem != null) list.AddRange(AfpRem);
        if (FonasaRem != null) list.AddRange(FonasaRem);
        if (IpsRem != null) list.AddRange(IpsRem);
        if (BanmedicaRem != null) list.AddRange(BanmedicaRem);
        if (Septiembre18Rem != null) list.AddRange(Septiembre18Rem);
        if (Credito18Septiembre != null) list.AddRange(Credito18Septiembre);
        if (CchcRem != null) list.AddRange(CchcRem);
        if (IslRem != null) list.AddRange(IslRem);
        if (CruzBlancaRem != null) list.AddRange(CruzBlancaRem);
        if (MasVidaRem != null) list.AddRange(MasVidaRem);

        return list;
    }

    public Cotizacion GetCotizacion(int month, int year)
    {
        var cotizacion = Cotizacion.CotizacionBuilder.Create(month, year);

        if (AfpRem != null) cotizacion = cotizacion.WithCotizacionAfp(AfpRem);
        if (FonasaRem != null) cotizacion = cotizacion.WithSalud(FonasaRem);

        return cotizacion.Build();
    }

    public int GetImponible()
    {
        if (AfpRem != null) return AfpRem.Max(j => j.RemuneracionImponible);
        if (FonasaRem != null) return FonasaRem.Max(j => j.Remuneracion);
        throw new Exception("No se pudo obtener el imponible");
    }
}