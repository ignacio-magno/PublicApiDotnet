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