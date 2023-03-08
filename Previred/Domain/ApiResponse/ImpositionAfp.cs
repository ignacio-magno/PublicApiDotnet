using Previred.Domain.Entities;

namespace Previred.Domain.ApiResponse;

public class ImpositionAfp
{
    public Afp? Afp { get; internal set; }
    public int CotizacionObligatorio { get; internal set; }
    public int Sis { get; internal set; }
    public int SeguroCesantia { get; internal set; }

    public int Imponible { get; internal set; }
}