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