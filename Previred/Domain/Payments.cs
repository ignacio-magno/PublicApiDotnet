using Previred.Domain.ApiResponse;

namespace Previred.Domain;

public class Payments
{
    public FonasaPayment Fonasa { get; private set; }
    public AfpPayment Afp { get; set; }

    internal Payments(ValuesCotizacionEmployee values)
    {
        SetFonasa(values);
        SetAfp(values);
    }

    private void SetAfp(ValuesCotizacionEmployee values)
    {
        var afp = values.AfpRem;
        var imponible = afp?.Sum(x => x.GetImponible()) ?? 0;
        var cotizacionObligatoria = afp?.Sum(x => x.CotizacionObligatoria) ?? 0;
        var seguroInvalidez = afp?.Sum(x => x.Sis) ?? 0;
        var seguroCesantia = afp?.Sum(x => x.CotizacionAfiliado) ?? 0;
        var seguroCesantiaEmpleador = afp?.Sum(x => x.CotizacionEmpleador) ?? 0;
        var cotizacionVoluntariaIndividualApvi = afp?.Sum(x => x.CotizacionVoluntaria) ?? 0;
        Afp = new AfpPayment(imponible, cotizacionObligatoria, seguroInvalidez, seguroCesantia,
            seguroCesantiaEmpleador, cotizacionVoluntariaIndividualApvi);
    }

    private void SetFonasa(ValuesCotizacionEmployee values)
    {
        IEnumerable<ITotals> fonasa = values.FonasaRem;

        var payment = fonasa?.Sum(x => x.GetTotalPaidByEmployees()) ?? 0;
        var imponible = fonasa?.Sum(x => x.GetImponible()) ?? 0;
        Fonasa = new FonasaPayment(payment, imponible);
    }
}

public class AfpPayment
{
    public int CotizacionVoluntariaIndividual_APVI { get; set; }
    public int Imponible { get; set; }
    public int CotizacionObligatoria { get; set; }
    public int SeguroInvalidezYSobrevivencia { get; set; }
    public int SeguroCesantia { get; set; }
    public int SeguroCesantiaEmpleador { get; set; }
    public int SeguroCesantiaTotal => SeguroCesantia + SeguroCesantiaEmpleador;

    public AfpPayment(int imponible, int cotizacionObligatoria, int seguroInvalidezYSobrevivencia, int seguroCesantia,
        int seguroCesantiaEmpleador, int cotizacionVoluntariaIndividualApvi)
    {
        Imponible = imponible;
        CotizacionObligatoria = cotizacionObligatoria;
        SeguroInvalidezYSobrevivencia = seguroInvalidezYSobrevivencia;
        SeguroCesantia = seguroCesantia;
        SeguroCesantiaEmpleador = seguroCesantiaEmpleador;
        CotizacionVoluntariaIndividual_APVI = cotizacionVoluntariaIndividualApvi;
    }
}