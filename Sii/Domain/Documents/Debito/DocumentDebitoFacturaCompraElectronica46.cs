using Sii.Domain.Fisco;

namespace Sii.Domain.Documents.Debito;

internal class DocumentDebitoFacturaCompraElectronica46 : DocumentBase
{
    internal override TypeDocumentFiscal TypeDocumentFiscal => TypeDocumentFiscal.DebitoFacturaCompraElectronica46;
    public override int FactorTotals => 1;

    public DocumentDebitoFacturaCompraElectronica46(BookFacturas facturases) : base(facturases)
    {
    }

    public DocumentDebitoFacturaCompraElectronica46(PagoFiscalValues fisco) : base(fisco)
    {
    }

    public DocumentDebitoFacturaCompraElectronica46(PagoFiscalValues fisco, BookFacturas facturases) : base(fisco,
        facturases)
    {
    }
}