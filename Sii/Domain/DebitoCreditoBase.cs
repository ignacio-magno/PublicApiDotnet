using Sii.Domain.ApiParse;
using Sii.Domain.Documents;
using Sii.Domain.Filters;
using Sii.Domain.Fisco;

namespace Sii.Domain;

public abstract class DebitoCreditoBase<T> : PagoFiscalValues where T : DebitoCreditoBase<T>
{
    public List<DocumentBase> Documents;
    public override Iva Iva => (Iva)Documents.Sum(x => x.Fisco.Iva);
    public override Neto Neto => (Neto)Documents.Sum(x => x.Fisco.Neto);
    public override Exento Exento => (Exento)Documents.Sum(x => x.Fisco.Exento);
    public override Total Total => (Total)Documents.Sum(j => j.Fisco.Total);

    public IEnumerable<PagoFiscalToSumValues> PagoFiscalToSumValues => Documents.Select(j => j.PagoFiscalToSumValues);

    public DebitoCreditoBase() => Documents = new List<DocumentBase>();

    internal DebitoCreditoBase(IEnumerable<DocumentBase> documents)
    {
        Documents = documents.ToList();
        if (Documents.Any(j => j.TypeDocumentFiscal == default))
            throw new InvalidOperationException("No se puede crear un documento sin tipo de documento");
    }

    public DocumentBase? Get(TypeDocumentFiscal factura33) => Documents.FirstOrDefault();

    public void AddDocument(DocumentBase documentCredito)
    {
        if (Documents.Any(x => x.GetType() == documentCredito.GetType()))
            throw new InvalidOperationException("No se puede agregar el mismo documento");
        if (!IsDocumentValid(documentCredito))
            throw new InvalidOperationException("No se puede agregar el documento, pertenece a otro tipo de documento");
        Documents.Add(documentCredito);
    }

    public abstract bool IsDocumentValid(DocumentBase document);

    public T NewDebitoCreditoFromFacturas(FilterFacturas makeFilterByRut)
    {
        var newCredito = (T)Activator.CreateInstance(typeof(T), true);

        if (newCredito == null) throw new InvalidOperationException("No se puede crear una instancia de la clase");

        foreach (var document in Documents)
        {
            var newDocument = document.FacturasInDocument?.NewWithFacturasSelected(makeFilterByRut);
            if (newDocument != null)
                newCredito.AddDocument(new DocumentBase.Builder()
                    .WithFacturas(newDocument)
                    .WithTypeDocumentFiscal(document.TypeDocumentFiscal)
                    .Build());
        }

        return newCredito;
    }
}