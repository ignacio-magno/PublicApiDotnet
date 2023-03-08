namespace Previred.Domain.ApiResponse;

public interface ITotals
{
    public int GetTotalPaidByEmployees();
    public int GetTotalPaidByEmployer();
    // cualquier dato que vaya en favor del trabajador
    public int GetBonos();
}