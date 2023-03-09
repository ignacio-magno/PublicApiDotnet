using Previred.Domain.ApiResponse;

namespace Previred.Domain;

public class Employee
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Rut { get; set; }

    public Payments Payments;

    internal Employee(ValuesCotizacionEmployee values)
    {
        Name = values.Name;
        Rut = values.Rut;
        Payments = new Payments(values);
    }
}

public class Payments
{
    public FonasaPayment Fonasa { get; set; }

    internal Payments(ValuesCotizacionEmployee values)
    {
        IEnumerable<ITotals> fonasa = values.FonasaRem;

        Fonasa = new FonasaPayment(fonasa?.Sum(x => x.GetTotalPaidByEmployees()) ?? 0);
    }
}

// Fonasa payment never has a payment from the employer
public class FonasaPayment
{
    public int ByEmployee { get; set; }

    public FonasaPayment(int byEmployee)
    {
        ByEmployee = byEmployee;
    }
}