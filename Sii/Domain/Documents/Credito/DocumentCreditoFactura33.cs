using Sii.Domain.Fisco;

namespace Sii.Domain.Documents.Credito;

internal class DocumentCreditoFactura33 : DocumentBase
{
    internal override TypeDocumentFiscal TypeDocumentFiscal => TypeDocumentFiscal.CreditoFactura33;
    public override int FactorTotals => 1;

    public DocumentCreditoFactura33(BookFacturas facturases) : base(facturases)
    {
    }

    public DocumentCreditoFactura33(PagoFiscalValues fisco) : base(fisco)
    {
    }

    // by default take facturas, if exist margin error 2 pesos, take again facturas.
    // repair this error in future
    public DocumentCreditoFactura33(PagoFiscalValues fisco, BookFacturas facturases) : base(fisco, facturases)
    {
    }
}