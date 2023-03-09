namespace Previred.Domain.ApiResponse;

internal interface ITotals
{
    public int GetTotalPaidByEmployees();

    public int GetTotalPaidByEmployer();

    // cualquier dato que vaya en favor del trabajador
    public int GetBonos();
    public int GetImponible();
    public MovPersonal MovPersonal { get; set; }
}