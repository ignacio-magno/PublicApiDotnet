using FluentAssertions;
using Sii.Domain;
using Sii.Domain.Filters;
using Sii.Domain.Fisco;

namespace SiiTesting;

public class FacturasTesting
{
    [Test]
    public void FacturasSum()
    {
        var facturas = Extensions2.WithFactura(Extensions2.WithFactura(Extensions2.WithFactura(A.Facturas(), 10000), 20000), 30000);
        ((int)facturas.Total).Should().Be(60000);
    }

    [Test]
    public void RemoveFactura()
    {
        var facturas = Extensions2.WithFactura(Extensions2.WithFactura(Extensions2.WithFactura(A.Facturas(), 10000), 20000), 30000);
        facturas.DeleteFirst();
        ((int)facturas.Total).Should().Be(50000);
    }

    [Test]
    public void FilterFacturasByRut()
    {
        var provider = A.Provider();
        var sut = Extensions2.WithFacturaFromProvider(Extensions2.WithFactura(Extensions2.WithFactura(Extensions2.WithFactura(A.Facturas(), 10000), 20000), 30000), provider, makeFactura =>
            {
                makeFactura(40000);
                makeFactura(50000);
                makeFactura(30000);
                makeFactura(20000);
            });

        sut.Filter(provider.MakeFilterByRut());

        ((int)sut.Total).Should().Be(60000);
    }

    [TestCase("Picada del perro", "picada del gato", "picada")]
    [TestCase("Picada del perro", "picada del gato", "Picada")]
    [TestCase("Picada del perro", "Picada del gato", "Picada")]
    public void FilterFacturasByRazonSocial(string business1, string business2, string filterText)
    {
        var provider = Extensions2.WithName(A.Provider(), business1);
        var provider2 = Extensions2.WithName(A.Provider(), business2);
        var sut = Extensions2.WithFacturaFromProvider(Extensions2.WithFacturaFromProvider(Extensions2.WithFactura(Extensions2.WithFactura(Extensions2.WithFactura(A.Facturas(), 10000), 20000), 30000), provider, makeFactura =>
            {
                makeFactura(40000);
                makeFactura(50000);
                makeFactura(30000);
                makeFactura(20000);
            }), provider2, makeFactura =>
            {
                makeFactura(40000);
                makeFactura(50000);
                makeFactura(30000);
                makeFactura(20000);
            });

        var filter = FilterFacturas.Builder.New().ByRazonSocial(filterText).BuildOnlyTrue();
        sut.Filter(filter);
        ((int)sut.Total).Should().Be(280000);
    }

    [Test]
    public void CreateNewCreditoFromOldCredito_WithFilterFacturas()
    {
        var provider = A.Provider();
        var sut = Extensions2.WithFacturaFromProvider(Extensions2.WithFactura(Extensions2.WithFactura(Extensions2.WithFactura(A.Facturas(), 10000), 20000), 30000), provider, makeFactura =>
            {
                makeFactura(40000);
                makeFactura(50000);
                makeFactura(30000);
                makeFactura(20000);
            });


        var filter = provider.MakeFilterByRut();
        var newFacturas = sut.NewWithFacturasSelected(filter);

        ((int)newFacturas.Total).Should().Be(60000);
        ((int)sut.Total).Should().Be(200000);
    }

    class A
    {
        public static BookFacturas Facturas()
        {
            return new BookFacturas(new List<Factura>());
        }

        public static Factura Factura(int total)
        {
            return NewFactura(total);
        }

        public static ProviderFactura Provider()
        {
            return new ProviderFactura(Faker.Company.Name(),
                $"{Faker.RandomNumber.Next(10000000, 99999999)}-{Faker.RandomNumber.Next(0, 9)}");
        }
    }

    public static Factura NewFactura(int total)
    {
        var pagoFiscal = new PagoFiscal(new Total(total));

        return new Factura.Builder()
            .WithRazonSocial(Faker.Company.Name())
            .WithRutProveedor($"{Faker.RandomNumber.Next(10000000, 99999999)}-{Faker.RandomNumber.Next(0, 9)}")
            .WithPagoFiscal(pagoFiscal)
            .Build();
    }
}

static class Extensions2
{
    public static BookFacturas WithFactura(this BookFacturas bookFacturas, int total)
    {
        var factura = FacturasTesting.NewFactura(total);
        bookFacturas.Add(factura);
        return bookFacturas;
    }

    public static BookFacturas WithFacturaFromProvider(this BookFacturas bookFacturas, ProviderFactura provider,
        Action<Action<int>> createFactura)
    {
        void NewFunction(int total)
        {
            var factura = provider.MakeFactura(total);
            bookFacturas.Add(factura);
        }

        createFactura(NewFunction);
        return bookFacturas;
    }

    public static ProviderFactura WithName(this ProviderFactura provider, string name)
    {
        return new ProviderFactura(provider.Rut, name);
    }
}