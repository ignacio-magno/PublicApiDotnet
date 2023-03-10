using Newtonsoft.Json;

namespace Sii.Domain.ApiParse;

internal class Resume
{
    [JsonProperty("dcvCodigo")] public int Codigo { get; set; }
    [JsonProperty("dcvNombreTipoDoc")] public string NomTipoDoc { get; set; }
    [JsonProperty("rsmnTipoDocInteger")] public int ResumeCodigo { get; set; }
    [JsonProperty("rsmnTotDoc")] public int TotalDocs { get; set; }
    [JsonProperty("dcvTipoIngresoDoc")] public string TipoDoc { get; set; }

    [JsonProperty("rsmnLink")] public bool IsLink { get; set; }
    [JsonProperty("rsmnMntExe")] public int Exento { get; set; }
    [JsonProperty("rsmnMntNeto")] public int Neto { get; set; }
    [JsonProperty("rsmnMntIVA")] public int Iva { get; set; }
    [JsonProperty("rsmnMntIVANoRec")] public int IvaNoRec { get; set; }
    [JsonProperty("rsmnMntTotal")] public int Total { get; set; }
    [JsonProperty("hrefFile")] public string KeyFile { get; set; }

    public Facturas? Facturas;

    public Resume Clone()
    {
        return (Resume)MemberwiseClone();
    }
}