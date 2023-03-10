using Sii.Domain.Fisco;

namespace Sii.Domain.Documents.Debito;

internal class DocumentDebitoBoleta39 : DocumentBase
{
    internal override TypeDocumentFiscal TypeDocumentFiscal => TypeDocumentFiscal.DebitoBoletaElectronica39;
    public override int FactorTotals => 1;

    public DocumentDebitoBoleta39(BookFacturas facturases) : base(facturases)
    {
    }

    public DocumentDebitoBoleta39(PagoFiscalValues fisco) : base(fisco)
    {
    }

    public DocumentDebitoBoleta39(PagoFiscalValues fisco, BookFacturas facturases) : base(fisco, facturases)
    {
    }

}