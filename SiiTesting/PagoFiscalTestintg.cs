using FluentAssertions;
using Sii.Domain.ApiParse;
using Sii.Domain.Fisco;

namespace SiiTesting;

public class PagoFiscalTestintg
{
    [DatapointSource] IEnumerable<PagoFiscal> datas = A.ListPagoFiscal;
    private int rangeError = 4;

    [Theory]
    public void CalculateIvaFromTotal(PagoFiscal pagoFiscal)
    {
        var newPagoFiscal = new PagoFiscal(pagoFiscal.Total);
        var dif = PagoFiscal.Dif<Total>(pagoFiscal, newPagoFiscal);
        dif.Should().BeLessThanOrEqualTo(rangeError);
    }

    [Theory]
    public void CalculateIvaFromNeto(PagoFiscal pagoFiscal)
    {
        var iva = new PagoFiscal(pagoFiscal.Neto);
        var dif = PagoFiscal.Dif<Iva>(pagoFiscal, iva);
        dif.Should().BeLessThanOrEqualTo(rangeError);
    }

    [Theory]
    public void CalculateTotalFromNeto(PagoFiscal pagoFiscal)
    {
        var newPagoFiscal = new PagoFiscal(pagoFiscal.Neto);
        var dif = PagoFiscal.Dif<Total>(pagoFiscal, newPagoFiscal);
        dif.Should().BeLessThanOrEqualTo(rangeError);
    }

    [Theory]
    public void CalculateTotalFromIva(PagoFiscal pagoFiscal)
    {
        var newPagoFiscal = new PagoFiscal(pagoFiscal.Iva);
        var dif = PagoFiscal.Dif<Total>(pagoFiscal, newPagoFiscal);
        dif.Should().BeLessThanOrEqualTo(rangeError);
    }

    [Theory]
    public void CalculateNetoFromIva(PagoFiscal pagoFiscal)
    {
        var sut = new PagoFiscal(pagoFiscal.Iva);
        var dif = PagoFiscal.Dif<Neto>(pagoFiscal, sut);
        dif.Should().BeLessThanOrEqualTo(rangeError);
    }

    [Theory]
    public void CalculateNetoFromTotal(PagoFiscal pagoFiscal)
    {
        var sut = new PagoFiscal(pagoFiscal.Total);
        var dif = PagoFiscal.Dif<Neto>(pagoFiscal, sut);
        dif.Should().BeLessThanOrEqualTo(rangeError);
    }


    class A
    {
        private SummaryData summary;

        public static IEnumerable<PagoFiscal> ListPagoFiscal
        {
            get
            {
                return new[]
                {
                    new PagoFiscal((Exento)0, (Neto)370000, (Iva)70300, (Total)440300),
                    new PagoFiscal((Exento)0, (Neto)600000, (Iva)114000, (Total)714000),
                    new PagoFiscal((Exento)0, (Neto)53773, (Iva)10217, (Total)63990),
                    new PagoFiscal((Exento)0, (Neto)16000, (Iva)3040, (Total)19040),
                    new PagoFiscal((Exento)0, (Neto)16000, (Iva)3040, (Total)19040),

                    new PagoFiscal((Exento)0, (Neto)27849, (Iva)5291, (Total)33140),
                    new PagoFiscal((Exento)0, (Neto)166608, (Iva)31656, (Total)198264),
                    new PagoFiscal((Exento)0, (Neto)88779, (Iva)16868, (Total)105647),
                    new PagoFiscal((Exento)0, (Neto)53230, (Iva)10113, (Total)63343),
                    new PagoFiscal((Exento)0, (Neto)46548, (Iva)8844, (Total)55392),
                    new PagoFiscal((Exento)0, (Neto)211932, (Iva)40267, (Total)252199),
                    new PagoFiscal((Exento)0, (Neto)131705, (Iva)25024, (Total)156729),
                };
            }
        }

        public SummaryData GetSummaryData()
        {
            var resume = new Resume()
            {
                Codigo = 0,
                IsLink = false,
                Exento = 0,
                Neto = 0,
                Iva = 0,
                Total = 0,
                ResumeCodigo = 39,
                TotalDocs = 140,
                NomTipoDoc = "unkmnow",
                TipoDoc = "dte elect",
                IvaNoRec = 0,
            };

            return new SummaryData()
            {
                Data = new[] { resume }
            };
        }
    }
}