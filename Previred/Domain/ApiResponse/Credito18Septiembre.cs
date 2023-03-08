namespace Previred.Domain.ApiResponse;

internal class Credito18Septiembre : ITotals
{
    public int CreditosPersonales { get; set; }
    public int ConveniosDentales { get; set; }
    public int Leasing { get; set; }
    public int SegurosVida { get; set; }
    public int Otros { get; set; }

    public int GetTotalPaidByEmployees()
    {
        return ConveniosDentales + Leasing + SegurosVida + Otros;
    }

    public int GetTotalPaidByEmployer()
    {
        return 0;
    }

    public int GetBonos() => 0;
}