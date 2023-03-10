using DotNetEnv;
using FluentAssertions;
using Sii;
using Sii.Api;
using Sii.Domain.ApiParse;

namespace SiiTesting;

[TestFixture]
//[Ignore("integration test")]
internal class Tests
{
    [SetUp]
    public void Setup()
    {
        Env.Load();
    }


    IEnumerable<DateTime> DateTimes = new List<DateTime>()
    {
        new(2022, 1, 1)
    };

    [Test]
    public async Task GetSummary()
    {
        var result = await A.ApiSii.GetSummaryCompraVenta(DateTimes);
        result.Should().NotBeNull();
    }

    [TestCaseSource(typeof(A), nameof(A.resumesCompras))]
    public void SummaryWithFacturasCompras(Resume resume)
    {
        var result = A.ApiSii.GetDetailsFacturasCompra(resume).Result;
        result.Should().NotBeNull();
    }

    [TestCaseSource(typeof(A), nameof(A.resumesVentas))]
    public void SummaryWithFacturasVentas(Resume resume)
    {
        var result = A.ApiSii.GetDetailsFacturasVenta(resume).Result;
        result.Should().NotBeNull();
    }

    [Test]
    public async Task SummaryCompraVenta()
    {
        var compraVenta = await A.SiiClient().GetSummaryCompraVentaWithFacturas(1, 2022);

        compraVenta.Credito.Should().NotBeNull();
        compraVenta.Debito.Should().NotBeNull();
    }

    class A
    {
        public ApiSii Sii { get; set; }

        private A()
        {
            Env.Load();
            Sii = new ApiSii(
                new HttpClient(),
                Env.GetString("TokenApi"),
                Env.GetString("SII_USERNAME"),
                Env.GetString("SII_PASSWORD")
            );
        }

        // singletoon

        private static A? _instance;

        public static ApiSii ApiSii => _instance?.Sii ?? new A().Sii;
        public static IEnumerable<Resume> resumesCompras = GetResumes(true);
        public static IEnumerable<Resume> resumesVentas = GetResumes(false);

        public static IEnumerable<Resume> GetResumes(bool isCompra)
        {
            var date = new DateTime(2022, 1, 1);
            var res = A.ApiSii.GetSummaryCompraVenta(new[] { date }).Result;

            if (res.Compra.Data != null && isCompra)
                foreach (var resume in res.Compra.Data)
                    if (resume.IsLink)
                        yield return resume;

            if (res.Venta.Data != null && !isCompra)
                foreach (var resume in res.Venta.Data)
                    if (resume.IsLink)
                        yield return resume;
        }

        public static implicit operator ApiSii(A p) => p.Sii;


        public static SiiClient SiiClient()
        {
            return new SiiClient(new HttpClient(), Env.GetString("TokenApi"), Env.GetString("SII_USERNAME"),
                Env.GetString("SII_PASSWORD"));
        }
    }
}