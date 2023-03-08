namespace Previred.Domain.ApiResponse;

internal class Imposition : ICloneable
{
    public int Id { get; set; }

    public int Month { get; set; }
    public int Year { get; set; }

    public int BusinessId { get; set; }
    public string KeyRemunerationFile { get; set; }
    public DateTime CreatedAt { get; set; }

    public List<ValuesCotizacionEmployee> ValuesCotizacionEmployee { get; set; }

    public object Clone() => this.MemberwiseClone();
}