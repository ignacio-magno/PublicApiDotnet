namespace Previred.Domain.ApiResponse;

public class ImpositionMovimientos
{
    public List<Movimiento>? Movimientos { get; internal set; }

    public ImpositionMovimientos(int month, int year)
    {
    }

    public class Movimiento
    {
        public DateTime Inicio { get; internal set; }
        public DateTime Termino { get; internal set; }
        internal TipoMov TipoMov { get; set; }

        public bool ContratoNuevo =>
            TipoMov is TipoMov.InicioRelacionLaboral or TipoMov.ContratoIndefinido;

        public bool FinContrato =>
            TipoMov == TipoMov.TerminoContrato;

        public bool SuspensionCovid =>
            TipoMov == TipoMov.SuspensionContratoPactoLey21227 ||
            TipoMov == TipoMov.SuspensionContratoActoAutoridadLey21227;

        public bool SubsidioMedico =>
            TipoMov == TipoMov.SubsidiosMedicos;
    }

    public bool SinCambios =>
        Movimientos?.All(m => m.TipoMov == TipoMov.SinMovimiento) ?? true;

    public bool ContratoNuevo =>
        Movimientos?.Any(m => m.ContratoNuevo) ?? false;

    public Movimiento? ContratoNuevoMov =>
        Movimientos?.Where(m => m.ContratoNuevo).OrderByDescending(m => m.Inicio).FirstOrDefault();

    public bool FinContrato =>
        Movimientos?.Any(m => m.FinContrato) ?? false;

    public bool SuspensionCovid =>
        Movimientos?.Any(m => m.SuspensionCovid) ?? false;

    public bool SubsidioMedico =>
        Movimientos?.Any(m => m.SubsidioMedico) ?? false;

    internal void Add(Movimiento mov)
    {
        if (Movimientos == null) Movimientos = new List<Movimiento>();

        var repeated = Movimientos.Any(j => j.Inicio == mov.Inicio && j.Termino == mov.Termino);
        if (!repeated)
        {
            Movimientos.Add(mov);
        }
    }
}