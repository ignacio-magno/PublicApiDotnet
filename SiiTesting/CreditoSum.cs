using FluentAssertions;
using Sii.Domain.Documents;
using Sii.Domain.Fisco;

namespace SiiTesting;

public partial class CreditoTesting
{
    [Test]
    public void NotCanAddSameDocument()
    {
        var document = new DocumentBase.Builder()
            .WithFacturas(Extensions2.WithFactura(Extensions2.WithFactura(CreditoTesting.A.Facturas(), 30000), 20000))
            .WithTypeDocumentFiscal(TypeDocumentFiscal.CreditoFactura33)
            .Build();

        var credito = Extensions.WithDocument(CreditoTesting.A.Credito(), document);

        Action act = () => credito.AddDocument(document);

        act.Should().Throw<InvalidOperationException>();
    }

    [Test]
    public void SumCredito()
    {
        var factura33 = new DocumentBase.Builder()
            .WithFacturas(Extensions2.WithFactura(Extensions2.WithFactura(CreditoTesting.A.Facturas(), 50000), 100000))
            .WithTypeDocumentFiscal(TypeDocumentFiscal.CreditoFactura33)
            .Build();

        var exenta34 = new DocumentBase.Builder()
            .WithFacturas(Extensions2.WithFactura(Extensions2.WithFactura(CreditoTesting.A.Facturas(), 20000), 30000))
            .WithTypeDocumentFiscal(TypeDocumentFiscal.CreditoFacturaExenta34)
            .Build();

        var credito = Extensions.WithDocument(Extensions.WithDocument(CreditoTesting.A.Credito(), factura33), exenta34);

        ((int)credito.Total).Should().Be(200000);
    }

    [Test]
    public void DebitoWithNotaDeCredito()
    {
        var factura33 = new DocumentBase.Builder()
            .WithFacturas(Extensions2.WithFactura(CreditoTesting.A.Facturas(), 50000))
            .WithTypeDocumentFiscal(TypeDocumentFiscal.CreditoFactura33)
            .Build();

        var notaCredito61 = new DocumentBase.Builder()
            .WithFacturas(Extensions2.WithFactura(CreditoTesting.A.Facturas(), 10000))
            .WithTypeDocumentFiscal(TypeDocumentFiscal.CreditoNotaDeCredito61)
            .Build();

        var credito = Extensions.WithDocument(Extensions.WithDocument(CreditoTesting.A.Credito(), notaCredito61), factura33);

        ((int)credito.PagoFiscalToSumValues.Sum(j=> j.Total)).Should().Be(40000);
    }

    [Test]
    public void CreditoNotCanReceiveDocumentForDebito()
    {
        var boleta39Debito = new DocumentBase.Builder()
            .WithFisco(new PagoFiscal(50000))
            .WithTypeDocumentFiscal(TypeDocumentFiscal.DebitoBoletaElectronica39)
            .Build();

        var action = () => CreditoTesting.A.Credito().AddDocument(boleta39Debito);

        action.Should().Throw<InvalidOperationException>();
    }

    [Test]
    public void DebitoNotCanReceiveDocumentForCredito()
    {
        var factura33Credito = new DocumentBase.Builder()
            .WithFisco(new PagoFiscal(50000))
            .WithTypeDocumentFiscal(TypeDocumentFiscal.CreditoFactura33)
            .Build();

        var action = () => CreditoTesting.A.Debito().AddDocument(factura33Credito);

        action.Should().Throw<InvalidOperationException>();
    }
}