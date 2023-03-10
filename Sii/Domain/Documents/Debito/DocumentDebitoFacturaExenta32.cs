using Sii.Domain.Fisco;

namespace Sii.Domain.Documents.Debito;

public class DocumentDebitoFacturaExenta32: DocumentBase
{
    public DocumentDebitoFacturaExenta32(BookFacturas facturases) : base(facturases)
    {
    }

    public DocumentDebitoFacturaExenta32(PagoFiscalValues fisco) : base(fisco)
    {
    }

    public DocumentDebitoFacturaExenta32(PagoFiscalValues fisco, BookFacturas facturases) : base(fisco, facturases)
    {
    }

    internal override TypeDocumentFiscal TypeDocumentFiscal => TypeDocumentFiscal.DebitoFacturaExenta32;
    public override int FactorTotals { get; }
}