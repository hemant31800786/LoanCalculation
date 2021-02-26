namespace LoanCalculation.Core.Repositories
{
    public interface ILoan
    {
        void YearlyStament();
        void MonthlyStament();
        void TotalInterestCalculation();
        double AdministrationFee(double loanAmount);

    }
}
