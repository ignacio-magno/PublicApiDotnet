namespace Previred.Domain;

/// <summary>
/// Fonasa payment never has a payment from the employer
/// </summary>
public class FonasaPayment
{
    public int ByEmployee { get; set; }
    public int Imponible { get; set; }

    public FonasaPayment(int byEmployee, int imponible)
    {
        ByEmployee = byEmployee;
        Imponible = imponible;
    }
}