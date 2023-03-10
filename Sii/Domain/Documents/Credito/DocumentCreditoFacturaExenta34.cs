using Sii.Domain.Fisco;

namespace Sii.Domain.Documents.Credito;

internal class DocumentCreditoFacturaExenta34 : DocumentBase
{
    internal override TypeDocumentFiscal TypeDocumentFiscal => TypeDocumentFiscal.CreditoFacturaExenta34;
    public override int FactorTotals => 1;

    public DocumentCreditoFacturaExenta34(BookFacturas facturases) : base(facturases)
    {
    }

    public DocumentCreditoFacturaExenta34(PagoFiscalValues fisco) : base(fisco)
    {
        throw new ArgumentException(
            "No se puede crear DocumentCreditoFacturaExenta34 con resumen, necesita las facturas");
    }

    public DocumentCreditoFacturaExenta34(PagoFiscalValues fisco, BookFacturas facturases) : base(fisco, facturases)
    {
    }
}