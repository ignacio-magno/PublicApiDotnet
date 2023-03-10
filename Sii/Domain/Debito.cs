using Sii.Domain.Documents;

namespace Sii.Domain;

public class Debito : DebitoCreditoBase<Debito>
{
    public Debito()
    {
    }

    public Debito(IEnumerable<DocumentBase> documents) : base(documents)
    {
        if (documents is null)
            throw new ArgumentNullException(nameof(documents));

        if (documents.Any(x => x.TypeDocumentFiscal.IsCredito()))
            throw new ArgumentException("No se puede crear Debito con documentos de credito");

        // check types of document all are diferents
        if (documents.GroupBy(x => x.TypeDocumentFiscal).Any(x => x.Count() > 1))
            throw new ArgumentException("No pueden existir documentos repetidos dentro del mismo doc.");
    }

    public override bool IsDocumentValid(DocumentBase document) => document.TypeDocumentFiscal.IsDebito();
}