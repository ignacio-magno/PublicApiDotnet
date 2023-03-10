namespace Sii.Domain.ApiParse;

internal class SummaryCompraVenta
{
    public SummaryData Compra { get; set; }
    public SummaryData Venta { get; set; }
    public Date Period { get; set; }
    public string Rut { get; set; }

    public class Date
    {
        public int Month { get; set; }
        public int Year { get; set; }
    }
}