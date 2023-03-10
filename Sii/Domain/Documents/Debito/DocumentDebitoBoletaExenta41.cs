using Sii.Domain.Fisco;

namespace Sii.Domain.Documents.Debito;

internal class DocumentDebitoBoletaExenta41 : DocumentBase
{
    internal override TypeDocumentFiscal TypeDocumentFiscal => TypeDocumentFiscal.DebitoBoletaExenta41;
    public override int FactorTotals => 1;

    public DocumentDebitoBoletaExenta41(BookFacturas facturases) : base(facturases)
    {
    }

    public DocumentDebitoBoletaExenta41(PagoFiscalValues fisco) : base(fisco)
    {
    }

    public DocumentDebitoBoletaExenta41(PagoFiscalValues fisco, BookFacturas facturases) : base(fisco, facturases)
    {
    }
}