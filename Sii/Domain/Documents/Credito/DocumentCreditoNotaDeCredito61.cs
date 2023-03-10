using Sii.Domain.Fisco;

namespace Sii.Domain.Documents.Credito;

internal class DocumentCreditoNotaDeCredito61 : DocumentBase
{
    internal override TypeDocumentFiscal TypeDocumentFiscal => TypeDocumentFiscal.CreditoNotaDeCredito61;
    public override int FactorTotals => -1;

    public DocumentCreditoNotaDeCredito61(BookFacturas facturases) : base(facturases)
    {
    }

    public DocumentCreditoNotaDeCredito61(PagoFiscalValues fisco) : base(fisco)
    {
        throw new ArgumentException(
            "No se puede crear DocumentCreditoNotaDeCredito61 con resumen, necesita las facturas");
    }

    public DocumentCreditoNotaDeCredito61(PagoFiscalValues fisco, BookFacturas facturases) : base(fisco, facturases)
    {
    }

}