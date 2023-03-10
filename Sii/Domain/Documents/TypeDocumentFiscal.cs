using Sii.Domain.Documents.Credito;
using Sii.Domain.Documents.Debito;

namespace Sii.Domain.Documents;

public enum TypeDocumentFiscal
{
    [TypeBuilder(Factura = true, IsCredito = true, Code = 32, TypeBuilder = typeof(DocumentCreditoFacturaExenta32))]
    CreditoFacturaExenta32 = 1,

    [TypeBuilder(Factura = true, IsCredito = true, Code = 33, TypeBuilder = typeof(DocumentCreditoFactura33))]
    CreditoFactura33,

    [TypeBuilder(Factura = true, IsCredito = true, Code = 34,
        TypeBuilder = typeof(DocumentCreditoFacturaExenta34))]
    CreditoFacturaExenta34,

    [TypeBuilder(Factura = true, IsCredito = true, Code = 61,
        TypeBuilder = typeof(DocumentCreditoNotaDeCredito61))]
    CreditoNotaDeCredito61,

    [TypeBuilder(Fisco = true, IsDebito = true, Code = 39, TypeBuilder = typeof(DocumentDebitoBoleta39))]
    DebitoBoletaElectronica39,

    [TypeBuilder(Fisco = true, IsDebito = true, Code = 41, TypeBuilder = typeof(DocumentDebitoBoletaExenta41))]
    DebitoBoletaExenta41,

    [TypeBuilder(Factura = true, IsDebito = true, Code = 46,
        TypeBuilder = typeof(DocumentDebitoFacturaCompraElectronica46))]
    DebitoFacturaCompraElectronica46,

    [TypeBuilder(Factura = true, IsDebito = true, Code = 33,
        TypeBuilder = typeof(DocumentDebitoFacturaElectronica33))]
    DebitoFacturaElectronica33,

    [TypeBuilder(Factura = true, IsDebito = true, Code = 32, TypeBuilder = typeof(DocumentDebitoFacturaExenta32))]
    DebitoFacturaExenta32,

    [TypeBuilder(Factura = true, IsDebito = true, Code = 61, TypeBuilder = typeof(DocumentDebitoNotaDeCredito61))]
    DebitoNotaDeCredito61,
}

internal class TypeBuilderAttribute : Attribute
{
    public bool Factura { get; set; }
    public bool Fisco { get; set; }

    public bool IsCredito { get; set; }
    public bool IsDebito { get; set; }
    public int Code { get; set; }
    public Type TypeBuilder { get; set; }
}