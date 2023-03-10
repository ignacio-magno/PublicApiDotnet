using Sii.Domain;
using Sii.Domain.ApiParse;
using Sii.Domain.Documents;
using Sii.Domain.Fisco;

namespace Sii;

public class CompraVenta
{
    public Debito? Debito { get; set; }
    public Credito? Credito { get; set; }

    public DateTime Period { get; set; }

    internal CompraVenta(SummaryCompraVenta summary)
    {
        Period = new DateTime(summary.Period.Year, summary.Period.Month, 1);

        Debito = summary.Venta.Data == null
            ? null
            : new Debito(GetDocuments(summary.Venta, TypeDocumentFiscalExtensions.ByCodeDebito));

        Credito = summary.Compra.Data == null
            ? null
            : new Credito(GetDocuments(summary.Compra, TypeDocumentFiscalExtensions.ByCodeCredito));
    }

    private IEnumerable<DocumentBase> GetDocuments(SummaryData summary,
        Func<int, TypeDocumentFiscal> obtainTypeDocumentByCode)
    {
        foreach (var resume in summary.Data!)
        {
            var builder = new DocumentBase.Builder();
            builder.WithFisco(new PagoFiscal(resume));

            if (resume.Facturas != null)
            {
                var facturas = new BookFacturas();
                foreach (var detailFactura in resume.Facturas.GetFacturas())
                    facturas.Add(new Factura(detailFactura));
                builder.WithFacturas(facturas);
            }

            builder.WithTypeDocumentFiscal(obtainTypeDocumentByCode(resume.ResumeCodigo));
            yield return builder.Build();
        }
    }


    public DocumentBase? GetCompraByCode(TypeDocumentFiscal type)
    {
        return Credito.Get(type);
    }

    public DocumentBase? GetVentaByCode(TypeDocumentFiscal type)
    {
        return Debito.Get(type);
    }
}