using Previred.Domain.ApiResponse;

namespace Previred.Domain;

public class Imposition
{
    public string Month { get; set; }
    public string Year { get; set; }
    public string RutBusiness { get; set; }
    public List<Employee> Employees { get; set; } = new List<Employee>();

    internal Imposition(ImpositionFromApi imposition)
    {
        foreach (var valuesCotizacionEmployee in imposition.ValuesCotizacionEmployee)
        {
            Employees.Add(new Employee(valuesCotizacionEmployee));
        }
    }
}