using Sii.Domain.Fisco;

namespace Sii.Domain.Documents.Debito;

public class DocumentDebitoNotaDeCredito61 : DocumentBase
{
    public DocumentDebitoNotaDeCredito61(BookFacturas facturases) : base(facturases)
    {
    }

    public DocumentDebitoNotaDeCredito61(PagoFiscalValues fisco) : base(fisco)
    {
    }

    public DocumentDebitoNotaDeCredito61(PagoFiscalValues fisco, BookFacturas facturases) : base(fisco, facturases)
    {
    }

    internal override TypeDocumentFiscal TypeDocumentFiscal => TypeDocumentFiscal.DebitoNotaDeCredito61;
    public override int FactorTotals => -1;
}