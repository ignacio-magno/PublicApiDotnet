namespace Previred.Domain;

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