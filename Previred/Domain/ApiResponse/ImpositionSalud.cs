namespace Previred.Domain.ApiResponse;

public class ImpositionSalud
{
    private const double Tolerance = 0.001;
    public int DiasTrabajados { get; internal set; }
    public int Imponible { get; internal set; }
    public int Cotizacion { get; internal set; }

    public bool Is7Porciento
    {
        get
        {
            if (Math.Abs(Imponible * 0.07 - Cotizacion) < Tolerance) return true;
            if (Math.Abs(Imponible * 0.039 - Cotizacion) < Tolerance) return false;

            throw new Exception("No se puede determinar si es 7% o 3,9%, real valor: ");
        }
    }
}