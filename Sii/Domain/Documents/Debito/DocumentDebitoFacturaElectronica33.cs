using Sii.Domain.Fisco;

namespace Sii.Domain.Documents.Debito;

public class DocumentDebitoFacturaElectronica33 : DocumentBase
{
    internal override TypeDocumentFiscal TypeDocumentFiscal => TypeDocumentFiscal.DebitoFacturaElectronica33;
    public override int FactorTotals => 1;

    public DocumentDebitoFacturaElectronica33(BookFacturas facturases) : base(facturases)
    {
    }

    public DocumentDebitoFacturaElectronica33(PagoFiscalValues fisco) : base(fisco)
    {
    }

    public DocumentDebitoFacturaElectronica33(PagoFiscalValues fisco, BookFacturas facturases) : base(fisco,
        facturases)
    {
    }
}