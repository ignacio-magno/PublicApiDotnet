namespace Previred.Domain.ApiResponse;

public class Cotizacion
{
    public ImpositionAfp? ImpositionAfp;
    public ImpositionSalud? ImpositionSalud;
    public ImpositionMovimientos ImpositionMovimientos;

    public Cotizacion(int month, int year)
    {
        ImpositionMovimientos = new ImpositionMovimientos(month, year);
    }


    internal class CotizacionBuilder
    {
        private Cotizacion c;

        private CotizacionBuilder(int month, int year)
        {
            c = new Cotizacion(month, year);
        }

        public static CotizacionBuilder Create(int month, int year)
        {
            return new CotizacionBuilder(month, year);
        }

        public CotizacionBuilder WithCotizacionAfp(IEnumerable<AfpRem> impositionAfp)
        {
            ImpositionAfp n = new ImpositionAfp();
            foreach (var afpRem in impositionAfp)
            {
                n.Afp = afpRem.Afp;
                n.SeguroCesantia += afpRem.CotizacionAfiliado;
                n.CotizacionObligatorio += afpRem.CotizacionObligatoria;
                n.Sis += afpRem.Sis;
                n.Imponible += afpRem.RemuneracionImponible;

                WithMovimientos(afpRem.MovPersonal);
            }

            c.ImpositionAfp = n;
            return this;
        }

        public CotizacionBuilder WithSalud(IEnumerable<FonasaRem> fonasa)
        {
            ImpositionSalud n = new ImpositionSalud();
            foreach (var fonasaRem in fonasa)
            {
                n.Cotizacion += fonasaRem.Cotizacion;
                n.Imponible += fonasaRem.Remuneracion;
                n.DiasTrabajados += fonasaRem.DiasTrabajados;


                WithMovimientos(fonasaRem.MovPersonal);
            }

            c.ImpositionSalud = n;
            return this;
        }

        private void WithMovimientos(MovPersonal movimiento)
        {
            if (movimiento.AnioInicio == 0 || movimiento.MesInicio == 0 || movimiento.DiaInicio == 0 ||
                movimiento.AnioTermino == 0 || movimiento.MesTermino == 0 || movimiento.DiaTermino == 0)
                return;

            var mov = new ImpositionMovimientos.Movimiento();
            mov.TipoMov = movimiento.TipoMov;
            mov.Inicio = new DateTime(movimiento.AnioInicio, movimiento.MesInicio, movimiento.DiaInicio);
            mov.Termino = new DateTime(movimiento.AnioTermino, movimiento.MesTermino, movimiento.DiaTermino);

            c.ImpositionMovimientos.Add(mov);
        }

        public Cotizacion Build() => c;
    }
}