namespace FinalProject
{
    public class CheckingAccount : Account
    {
        public CheckingAccount(long accountNumber, int pin, string firstName, string lastName, decimal balance, int numDeposits, int numWithdrawals) : base(accountNumber, pin, firstName, lastName, balance, numDeposits, numWithdrawals, accountType.Checking)
        {

        }
    }
}