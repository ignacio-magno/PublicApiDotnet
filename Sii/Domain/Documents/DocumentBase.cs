using Sii.Domain.Fisco;

namespace Sii.Domain.Documents;

public abstract partial class DocumentBase
{
    internal abstract TypeDocumentFiscal TypeDocumentFiscal { get; }

    public PagoFiscalValues Fisco
    {
        get { return FacturasInDocument ?? _fisco; }
        set { _fisco = value; }
    }

    public BookFacturas? FacturasInDocument { get; set; }
    private PagoFiscalValues? _fisco;

    public abstract int FactorTotals { get; }
    public PagoFiscalToSumValues PagoFiscalToSumValues => new(Fisco, FactorTotals);

    public DocumentBase(BookFacturas facturases) => FacturasInDocument = facturases;
    public DocumentBase(PagoFiscalValues fisco) => Fisco = fisco;

    public DocumentBase(PagoFiscalValues fisco, BookFacturas facturases)
    {
        if (facturases.Total != fisco.Total)
            throw new ArgumentException("Total de facturas no coincide con total de fisco", nameof(facturases));

        if (facturases.Neto != fisco.Neto)
            throw new ArgumentException(
                $"Neto de facturas no coincide con neto de fisco, dif {PagoFiscal.Dif<Neto>(facturases, fisco)} ",
                nameof(facturases));

        if (facturases.Iva != fisco.Iva)
            throw new ArgumentException("Iva de facturas no coincide con iva de fisco", nameof(facturases));

        if (facturases.Exento != fisco.Exento)
            throw new ArgumentException("Exento de facturas no coincide con exento de fisco", nameof(facturases));
        FacturasInDocument = facturases;
    }
}