namespace Sii.Api;

internal partial class ApiSii
{
    private string Password { get; }
    private string Username { get; }

    HttpClient client;

    private const string UrlPdf =
        "https://api.ignaciolp.cl/contabilidad/iva/resumen_compra_venta/file/pdf/default_data";

    private const string UrlXlsx =
        "https://api.ignaciolp.cl/contabilidad/iva/resumen_compra_venta/file/xlsx/default_data";

    private const string UrlSummaryIvaWithPersistence =
        "https://api.ignaciolp.cl/contabilidad/iva/resumen_compra_venta_with_persistence";


    public ApiSii(HttpClient client, string tokenApi, string username, string password)
    {
        if (string.IsNullOrEmpty(tokenApi))
        {
            throw new ArgumentException("Token Api is required");
        }

        this.client = client;
        this.client.DefaultRequestHeaders.Add("x-api-key", tokenApi);
        Username = username;
        Password = password;
    }
}