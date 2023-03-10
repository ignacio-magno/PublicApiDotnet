using Sii.Domain.Fisco;

namespace Sii.Domain.Documents;

public class PagoFiscalToSumValues : PagoFiscalValues
{
    public override Iva Iva { get; }
    public override Neto Neto { get; }
    public override Exento Exento { get; }
    public override Total Total { get; }

    public PagoFiscalToSumValues(PagoFiscalValues values, int factor)
    {
        Iva = (Iva)(values.Iva * factor);
        Neto = (Neto)(values.Neto * factor);
        Exento = (Exento)(values.Exento * factor);
        Total = (Total)(values.Total * factor);
    }
}