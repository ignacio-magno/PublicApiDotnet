using Previred.Domain.ApiResponse;

namespace Previred.Domain;

public class Movements
{
    private readonly IEnumerable<MovPersonal> _movs;

    internal Movements(IEnumerable<MovPersonal> movs)
    {
        _movs = movs;
    }

    public bool HasMovements => _movs.Any(j => j.TipoMov != TipoMov.SinMovimiento);
    public bool HasPermisoSinGoceDeSueldo => _movs.Any(j => j.TipoMov == TipoMov.PermSinGoseSueldo);

    public DetailMov? GetMovimientoByType(TipoMov tipoMov)
    {
        var finded = _movs.Where(j => j.TipoMov == tipoMov).ToArray();
        if (finded.Length > 1) CheckMovSameTypeHaveDifferentData(finded);
        if (finded.Length == 0) return null;
        return new DetailMov(finded.ElementAt(0));
    }

    private void CheckMovSameTypeHaveDifferentData(MovPersonal[] movs)
    {
        var first = movs.First();
        var rest = movs.Skip(1);

        foreach (var mov in rest)
        {
            if (first.DiaInicio != mov.DiaInicio) throw new Exception("Los movimientos no coinciden");
            if (first.MesInicio != mov.MesInicio) throw new Exception("Los movimientos no coinciden");
            if (first.AnioInicio != mov.AnioInicio) throw new Exception("Los movimientos no coinciden");
            if (first.DiaTermino != mov.DiaTermino) throw new Exception("Los movimientos no coinciden");
            if (first.MesTermino != mov.MesTermino) throw new Exception("Los movimientos no coinciden");
            if (first.AnioTermino != mov.AnioTermino) throw new Exception("Los movimientos no coinciden");
        }
    }
}