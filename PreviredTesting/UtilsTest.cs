using FluentAssertions;
using Previred.ClientApi;
using Previred.Domain;

namespace PreviredTesting;

public class UtilsTest
{
    [Test]
    public void Clients()
    {
        var imposition = A.Imposition();
        imposition.Employees.Count.Should().Be(2);
    }

    [Test]
    public void EmployeesPaymentFonasa()
    {
        var imposition = A.Imposition();
        var employee = imposition.Employees[0];
        var payments = employee.Payments;
        payments.Fonasa.ByEmployee.Should().BeGreaterThan(0);
    }

    [Test]
    public void EmployeesPaymentFonasaImponible()
    {
        var imposition = A.Imposition();
        var employee = imposition.Employees[0];
        var payments = employee.Payments;
        payments.Fonasa.Imponible.Should().BeGreaterThan(0);
    }

    [Test]
    public void EmployeesPaymentAfpImponible()
    {
        var imposition = A.Imposition();
        var employee = imposition.Employees[0];
        var payments = employee.Payments;
        payments.Afp.Imponible.Should().BeGreaterThan(0);
    }

    [Test]
    public void EmployeesPaymentAfpCotizacionObligatoria()
    {
        var imposition = A.Imposition();
        var employee = imposition.Employees[0];
        var payments = employee.Payments;
        payments.Afp.CotizacionObligatoria.Should().BeGreaterThan(0);
    }

    [Test]
    public void EmployeesPaymentAfp_SeguroInvalidezYSobrevivencia()
    {
        var imposition = A.Imposition();
        var employee = imposition.Employees[0];
        var payments = employee.Payments;
        payments.Afp.SeguroInvalidezYSobrevivencia.Should().BeGreaterThan(0);
    }

    [Test]
    public void EmployeesPaymentAfp_SeguroCesantia()
    {
        var imposition = A.Imposition();
        var employee = imposition.Employees[0];
        var payments = employee.Payments;
        payments.Afp.SeguroCesantia.Should().BeGreaterThan(0);
    }

    [Test]
    public void EmployeesPaymentAfp_SeguroCesantiaEmpleador()
    {
        var imposition = A.Imposition();
        var employee = imposition.Employees[0];
        var payments = employee.Payments;
        payments.Afp.SeguroCesantiaEmpleador.Should().BeGreaterThan(0);
    }

    [Test]
    public void EmployeesPaymentAfp_SeguroCesantiaTotal()
    {
        var imposition = A.Imposition();
        var employee = imposition.Employees[0];
        var payments = employee.Payments;
        payments.Afp.SeguroCesantiaTotal.Should().BeGreaterThan(0);
    }

    [Test]
    public void EmployeesPaymentAfp_CotizacionVoluntariaIndividual_APVI()
    {
        var imposition = A.Imposition();
        var employee = imposition.Employees[0];
        var payments = employee.Payments;
        payments.Afp.CotizacionVoluntariaIndividual_APVI.Should().Be(0);
    }
}

public static class A
{
    public static Imposition Imposition()
    {
        var client = new LambdaApi(new HttpClient(), Credentials.Instance.TokenApi);
        var response = client.DoFromFile(Credentials.Instance.PathFileTest).Result;

        return new Imposition(response);
    }
}