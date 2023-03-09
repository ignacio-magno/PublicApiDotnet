using Newtonsoft.Json;

namespace Previred.Domain.ApiResponse;

internal class MovPersonal
{
    [JsonProperty("cod_mov")] public TipoMov TipoMov { get; set; }

    [JsonProperty("dia_inicio")] public int DiaInicio { get; set; }
    [JsonProperty("mes_inicio")] public int MesInicio { get; set; }
    [JsonProperty("anio_inicio")] public int AnioInicio { get; set; }

    [JsonProperty("dia_termino")] public int DiaTermino { get; set; }
    [JsonProperty("mes_termino")] public int MesTermino { get; set; }
    [JsonProperty("anio_termino")] public int AnioTermino { get; set; }
}