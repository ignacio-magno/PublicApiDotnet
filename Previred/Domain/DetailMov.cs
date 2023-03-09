using Previred.Domain.ApiResponse;

namespace Previred.Domain;

public class DetailMov
{
    private readonly TipoMov _tipoMov;
    public DateTime? Inicio { get; set; }
    public DateTime Termino { get; set; }
    public bool HasCovid  => throw new NotImplementedException();

    internal DetailMov(MovPersonal finded)
    {
        if (finded.AnioInicio != default && finded.MesInicio != default && finded.DiaInicio != default)
            Inicio = new DateTime(finded.AnioInicio, finded.MesInicio, finded.DiaInicio);

        Termino = new DateTime(finded.AnioTermino, finded.MesTermino, finded.DiaTermino);
        _tipoMov = finded.TipoMov;
    }
}