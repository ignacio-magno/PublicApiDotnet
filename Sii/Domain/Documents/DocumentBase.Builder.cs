using Sii.Domain.Fisco;

namespace Sii.Domain.Documents;

public partial class DocumentBase
{
    public class Builder
    {
        private PagoFiscalValues? _fisco;
        private BookFacturas? _facturas;
        private TypeDocumentFiscal _typeDocumentFiscal;


        public Builder WithFacturas(BookFacturas bookFacturas)
        {
            if (_facturas is null)
                _facturas = bookFacturas;
            else
                _facturas.Facturas.AddRange(bookFacturas.Facturas);
            return this;
        }

        public Builder WithFisco(PagoFiscalValues fisco)
        {
            _fisco = fisco;
            return this;
        }

        public Builder WithTypeDocumentFiscal(TypeDocumentFiscal typeDocumentFiscal)
        {
            _typeDocumentFiscal = typeDocumentFiscal;
            return this;
        }

        public DocumentBase Build()
        {
            var type = _typeDocumentFiscal.GetBuilder();


            if (_facturas != null && _fisco != null)
                return (DocumentBase)Activator.CreateInstance(type, _fisco, _facturas) ??
                       throw new ArgumentException("No se puede crear DocumentBase sin facturas o fisco");

            if (_facturas != null)
                return (DocumentBase)Activator.CreateInstance(type, _facturas) ??
                       throw new ArgumentException("No se puede crear DocumentBase sin facturas o fisco");

            if (_fisco != null)
                return (DocumentBase)Activator.CreateInstance(type, _fisco) ??
                       throw new ArgumentException("No se puede crear DocumentBase sin facturas o fisco");

            throw new ArgumentException("No se puede crear DocumentBase sin facturas o fisco");
        }
    }
}