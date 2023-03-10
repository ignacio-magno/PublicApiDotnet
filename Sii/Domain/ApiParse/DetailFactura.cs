namespace Sii.Domain.ApiParse;

internal class DetailFactura
{
    public int Nro { get; set; }
    public int TypeBuy { get; set; }
    public string RutProvider { get; set; }
    public string RazonSocial { get; set; }
    public int Folio { get; set; }
    public DateTime DateDoc { get; set; }
    public DateTime DateReception { get; set; }
    public DateTime DateAcuse { get; set; }
    public int Exento { get; set; }
    public int Neto { get; set; }
    public int IvaRecuperable { get; set; }
    public int IvaNoRecuperable { get; set; }
    public int CodeIvaNoRec { get; set; }
    public int Total { get; set; }
    public int ValorOtroImpuesto { get; set; }
}