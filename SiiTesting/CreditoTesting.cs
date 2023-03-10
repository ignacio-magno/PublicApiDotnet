using FluentAssertions;
using Sii.Domain;
using Sii.Domain.Documents;
using Sii.Domain.Fisco;

namespace SiiTesting;

public partial class CreditoTesting
{
    [DatapointSource]
    TypeDocumentFiscal[] documentCreditos = Enum.GetValues<TypeDocumentFiscal>().Where(j => j.IsCredito()).ToArray();

    [Theory]
    public void ObtainDocumentCredito(TypeDocumentFiscal doc)
    {
        var document = new DocumentBase.Builder().WithFacturas(Extensions2.WithFactura(A.Facturas(), 10000))
            .WithTypeDocumentFiscal(doc).Build();
        var credito = Extensions.WithDocument(A.Credito(), document);
        var factura = credito.Get(doc);
        factura.Should().NotBeNull();
    }

    [Theory]
    public void ObtainNotExistDocumento(TypeDocumentFiscal doc)
    {
        var credito = A.Credito();
        var factura = credito.Get(doc);
        factura.Should().BeNull();
    }

    [Theory]
    public void ObtainFiscoDocumentFactura33(TypeDocumentFiscal doc)
    {
        var document = new DocumentBase.Builder().WithFacturas(Extensions2.WithFactura(A.Facturas(), 100000))
            .WithTypeDocumentFiscal(doc).Build();
        var credito = Extensions.WithDocument(A.Credito(), document);
        var factura = credito.Get(doc);
        factura.Fisco.Should().NotBeNull();
    }

    [Theory]
    public void Debito_BuildFromFacturas_FiscoValuesIsObtainedFromFacturas(TypeDocumentFiscal doc)
    {
        var facturas = Extensions2.WithFactura(Extensions2.WithFactura(Extensions2.WithFactura(A.Facturas(), 10000), 20000), 30000);
        var document = new DocumentBase.Builder().WithFacturas(facturas).WithTypeDocumentFiscal(doc).Build();
        var sut = Extensions.WithDocument(A.Credito(), document);

        var act = sut.Get(TypeDocumentFiscal.CreditoFactura33);

        ((int)act.Fisco.Total).Should().Be(60000);
    }

    [Theory]
    public void Debito_BuildedWithoutFacturas_ObtainigFisco(TypeDocumentFiscal doc)
    {
        if (!doc.ConstructorReceiveFisco()) return;

        var document = new DocumentBase.Builder().WithFisco(new PagoFiscal((Total)10000)).WithTypeDocumentFiscal(doc)
            .Build();
        var credito = Extensions.WithDocument(A.Credito(), document);
        var sut = credito.Get(doc);
        sut.Fisco.Should().NotBeNull();
    }

    [Theory]
    public void ToDebito_DeleteOneFactura_AffectToValues(TypeDocumentFiscal doc)
    {
        if (!doc.ConstructorReceiveFisco()) return;

        var document = new DocumentBase.Builder().WithFisco(new PagoFiscal((Total)10000)).WithTypeDocumentFiscal(doc)
            .Build();
        var sut = Extensions.WithDocument(A.Credito(), document);
        var factura = sut.Get(doc);

        ((int)factura.Fisco.Total).Should().Be(100000);
    }

    [Theory]
    public void DebitoBuildedFromSummaryAndFacturas_NotEqualsValues(TypeDocumentFiscal doc)
    {
        if (!doc.ConstructorReceiveFacturas()) return;
        if (!doc.ConstructorReceiveFisco()) return;

        var facturas = Extensions2.WithFactura(Extensions2.WithFactura(Extensions2.WithFactura(A.Facturas(), 10000), 20000), 30000);
        var summary = new PagoFiscal(new Total(50000));
        var document = new DocumentBase.Builder().WithFacturas(facturas).WithFisco(summary).WithTypeDocumentFiscal(doc)
            .Build();
        var action = () => Extensions.WithDocument(A.Credito(), document);
        action.Should().Throw<Exception>();
    }

    [Theory]
    public void DebitoBuildedFromSummaryAndFacturas_ValuesAreEqual(TypeDocumentFiscal doc)
    {
        if (!doc.ConstructorReceiveFacturas()) return;
        if (!doc.ConstructorReceiveFisco()) return;

        var facturas = Extensions2.WithFactura(Extensions2.WithFactura(Extensions2.WithFactura(A.Facturas(), 10000), 20000), 30000);
        var summary = new PagoFiscal(new Total(60000));
        var document = new DocumentBase.Builder().WithFacturas(facturas).WithFisco(summary).WithTypeDocumentFiscal(doc)
            .Build();
        var action = () => Extensions.WithDocument(A.Credito(), document);

        action.Should().NotThrow();
    }

    [Test]
    public void Credito_BuildNewCreditoFromFilterFacturas()
    {
        var provider = A.Provider();
        var facturas = Extensions2.WithFacturaFromProvider(Extensions2.WithFactura(Extensions2.WithFactura(Extensions2.WithFactura(A.Facturas(), 10000), 20000), 30000), provider,
            makeFactura =>
            {
                makeFactura(10000);
                makeFactura(20000);
                makeFactura(30000);
            });

        var document = new DocumentBase.Builder().WithFacturas(facturas)
            .WithTypeDocumentFiscal(TypeDocumentFiscal.CreditoFactura33).Build();
        var document2 = new DocumentBase.Builder().WithFacturas(facturas)
            .WithTypeDocumentFiscal(TypeDocumentFiscal.CreditoFacturaExenta32).Build();

        var sut = Extensions.WithDocument(Extensions.WithDocument(A.Credito(), document), document2);

        Credito newCredito = sut.NewDebitoCreditoFromFacturas(provider.MakeFilterByRut());

        ((int)newCredito.Total).Should().Be(120000);
        ((int)sut.Total).Should().Be(240000);
    }

    static class A
    {
        public static Credito Credito()
        {
            return new Credito();
        }

        public static BookFacturas Facturas()
        {
            return new BookFacturas(new List<Factura>());
        }

        public static Debito Debito()
        {
            return new Debito();
        }

        public static ProviderFactura Provider()
        {
            return new ProviderFactura(Faker.Company.Name(),
                $"{Faker.RandomNumber.Next(10000000, 99999999)}-{Faker.RandomNumber.Next(0, 9)}");
        }
    }
}

static class Extensions
{
    public static Credito WithDocument(this Credito credito, DocumentBase document)
    {
        credito.AddDocument(document);
        return credito;
    }
}