using FluentAssertions;
using Previred.Domain.ApiResponse;

namespace PreviredTesting;

public class MovimientosTest
{
    [Test]
    public void MovimientosMensuales()
    {
        var imposition = A.Imposition();
        var employee = imposition.Employees[0];
        var movements = employee.Movimientos;
        movements.HasMovements.Should().BeTrue();
    }

    [Test]
    public void MovimientosMensuales_HasPermisoSinGoceDeSueldo()
    {
        var imposition = A.Imposition();
        var employee = imposition.Employees[0];
        var movements = employee.Movimientos;
        movements.HasPermisoSinGoceDeSueldo.Should().BeTrue();
    }

    [Test]
    public void MovimientosMensuales_GetByType()
    {
        var imposition = A.Imposition();
        var employee = imposition.Employees[0];
        var movements = employee.Movimientos;
        var mov = movements.GetMovimientoByType(TipoMov.PermSinGoseSueldo);
        mov.Should().NotBeNull();
    }

    [Test]
    public void MovimientosMensuales_HasCovid()
    {
        var imposition = A.Imposition();
        var employee = imposition.Employees[0];
        var movements = employee.Movimientos;
        var mov = movements.GetMovimientoByType(TipoMov.PermSinGoseSueldo);
        mov.Should().NotBeNull();
        mov?.HasCovid.Should().BeFalse();
    }
}