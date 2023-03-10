using Sii.Domain.Fisco;

namespace Sii.Domain.Documents.Credito;

public class DocumentCreditoFacturaExenta32 : DocumentBase
{
    public DocumentCreditoFacturaExenta32(BookFacturas facturases) : base(facturases)
    {
    }

    public DocumentCreditoFacturaExenta32(PagoFiscalValues fisco) : base(fisco)
    {
    }

    public DocumentCreditoFacturaExenta32(PagoFiscalValues fisco, BookFacturas facturases) : base(fisco, facturases)
    {
    }

    internal override TypeDocumentFiscal TypeDocumentFiscal => TypeDocumentFiscal.CreditoFacturaExenta32;
    public override int FactorTotals => 1;
}