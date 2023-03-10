using Sii.Domain.Fisco;

namespace Sii.Domain;

public class Factura
{
    public ProviderFactura Provider { get; }
    public int Folio { get; }
    public DateTime FechaEmision { get; }
    public int Exento { get; }
    public int Neto { get; }
    public int IvaRecuperable { get; }
    public int IvaNoRecuperable { get; }
    public int Total { get; }

    internal Factura(ApiParse.DetailFactura factura)
    {
        Provider = new ProviderFactura(factura.RutProvider, factura.RazonSocial);
        Folio = factura.Folio;
        FechaEmision = factura.DateDoc;
        Exento = factura.Exento;
        Neto = factura.Neto;
        IvaRecuperable = factura.IvaRecuperable;
        IvaNoRecuperable = factura.IvaNoRecuperable;
        Total = factura.Total;
    }

    private Factura(string rutProveedor, string razonSocial, int folio, DateTime fechaEmision, int exento, int neto,
        int ivaRecuperable, int ivaNoRecuperable, int total)
    {
        Provider = new ProviderFactura(rutProveedor, razonSocial);
        Folio = folio;
        FechaEmision = fechaEmision;
        Exento = exento;
        Neto = neto;
        IvaRecuperable = ivaRecuperable;
        IvaNoRecuperable = ivaNoRecuperable;
        Total = total;
    }

    public class Builder
    {
        private string _rutProveedor;
        private string _razonSocial;
        private int _folio;
        private DateTime _fechaEmision;
        private int _exento;
        private int _neto;
        private int _ivaRecuperable;
        private int _ivaNoRecuperable;
        private int _total;

        public Builder WithRutProveedor(string rutProveedor)
        {
            _rutProveedor = rutProveedor;
            return this;
        }

        public Builder WithRazonSocial(string razonSocial)
        {
            _razonSocial = razonSocial;
            return this;
        }

        public Builder WithFolio(int folio)
        {
            _folio = folio;
            return this;
        }

        public Builder WithFechaEmision(DateTime fechaEmision)
        {
            _fechaEmision = fechaEmision;
            return this;
        }

        public Builder WithExento(int exento)
        {
            _exento = exento;
            return this;
        }

        public Builder WithNeto(int neto)
        {
            _neto = neto;
            return this;
        }

        public Builder WithIvaRecuperable(int ivaRecuperable)
        {
            _ivaRecuperable = ivaRecuperable;
            return this;
        }

        public Builder WithIvaNoRecuperable(int ivaNoRecuperable)
        {
            _ivaNoRecuperable = ivaNoRecuperable;
            return this;
        }

        public Builder WithTotal(int total)
        {
            _total = total;
            return this;
        }

        public Factura Build()
        {
            return new Factura(_rutProveedor, _razonSocial, _folio, _fechaEmision, _exento, _neto, _ivaRecuperable,
                _ivaNoRecuperable, _total);
        }

        public Builder WithPagoFiscal(PagoFiscal pagoFiscal)
        {
            _exento = pagoFiscal.Exento;
            _neto = pagoFiscal.Neto;
            _ivaRecuperable = pagoFiscal.Iva;
            _total = pagoFiscal.Total;
            return this;
        }
    }
}