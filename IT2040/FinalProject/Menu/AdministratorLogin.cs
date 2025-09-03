namespace FinalProject;
public class AdministratorLogin
{
    public static void DisplayMenu(List<Account> accountList)
    {
        Console.WriteLine("Welcome to administrative login\nEnter your admin username");
        string adminUsername = Console.ReadLine()!;
        Console.WriteLine("Enter your admin pin");
        int adminPin = int.Parse(Console.ReadLine()!);

        bool adminLoginValid = AdminLogin(adminUsername, adminPin, "admins.txt");
        if (adminLoginValid)
        {
            Console.WriteLine("\nLogin successful!\n");
        }
        else
        {
            Console.WriteLine("\nERROR: Invalid Credientials\n");
        }

        while (adminLoginValid == true)
        {
            Console.WriteLine("Administrator Login Menu:");
            Console.WriteLine("a. Show average savings account balance");
            Console.WriteLine("b. Show total savings account balance");
            Console.WriteLine("c. Show average checking account balance");
            Console.WriteLine("d. Show total checking account balance");
            Console.WriteLine("e. Show the number of accounts for each account type");
            Console.WriteLine("f. Show the 10 accounts with the most deposits");
            Console.WriteLine("g. Show the 10 accounts with the most withdrawals");
            Console.WriteLine("h. Back to main menu");

            Console.Write("Enter the option letter: ");
            string userInput = Console.ReadLine()!;

            switch (userInput)
            {
                case "a":
                    ShowAverageSavingsBalance(accountList);
                    break;
                case "b":
                    ShowTotalSavingsBalance(accountList);
                    break;
                case "c":
                    ShowAverageCheckingBalance(accountList);
                    break;
                case "d":
                    ShowTotalCheckingBalance(accountList);
                    break;
                case "e":
                    ShowAccountTypeCounts(accountList);
                    break;
                case "f":
                    ShowTopDepositAccounts(accountList);
                    break;
                case "g":
                    ShowTopWithdrawalAccounts(accountList);
                    break;
                case "h":
                    return; // Back to main menu
                default:
                    Console.WriteLine("Invalid input. Please enter a valid option letter.");
                    break;
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    static void ShowAverageSavingsBalance(List<Account> accountList)
    {
        var avgSavingsBalance = (from account in accountList
                                 where account.GetAccountType() == accountType.Savings
                                 select account.getBalance()).Average();

        Console.WriteLine($"{printALine()}Average Savings Balance: {avgSavingsBalance:c2} {printALine()}");

    }

    static void ShowTotalSavingsBalance(List<Account> accountList)
    {
        var totalSavingsbalance = (from account in accountList
                                   where account.GetAccountType() == accountType.Savings
                                   select account.getBalance()).Sum();
        Console.WriteLine($"{printALine()}Total Savings Balance: {totalSavingsbalance:c2}{printALine()}");
    }

    static void ShowAverageCheckingBalance(List<Account> accountList)
    {
        var avgCheckingBalance = (from account in accountList
                                  where account.GetAccountType() == accountType.Checking
                                  select account.getBalance()).Average();

        Console.WriteLine($"{printALine()}Average Checking Balance: {avgCheckingBalance:c2}{printALine()}");
    }

    static void ShowTotalCheckingBalance(List<Account> accountList)
    {
        var totalCheckingBalance = (from account in accountList
                                    where account.GetAccountType() == accountType.Checking
                                    select account.getBalance()).Sum();

        Console.WriteLine($"{printALine()}Total Checking Balance: {totalCheckingBalance:c2}{printALine()}");
    }

    static void ShowAccountTypeCounts(List<Account> accountList)
    {
        int numberOfSavingsAccounts = (from account in accountList
                                       where account.GetAccountType() == accountType.Savings
                                       select account).Count();

        int numberOfCheckingAccounts = (from account in accountList
                                        where account.GetAccountType() == accountType.Checking
                                        select account).Count();

        Console.WriteLine($"{printALine()} Checking Accounts: {numberOfCheckingAccounts}\nSavings Accounts: {numberOfSavingsAccounts}{printALine()}");

    }

    static void ShowTopDepositAccounts(List<Account> accountList)
    {
        var top10HighestDepositAccounts = (from account in accountList
                                           orderby account.getNumDeposits() descending
                                           select account).Take(10);

        Console.WriteLine(printALine() + "Highest deposited account(s)" + printALine());

        foreach (var account in top10HighestDepositAccounts)
        {
            Console.WriteLine($"Account {account.getAccountNumber()} | Deposits:{account.getNumDeposits()}");
        }
    }

    static void ShowTopWithdrawalAccounts(List<Account> accountList)
    {
        var top10HighestWithdrawalAccounts = (from account in accountList
                                              orderby account.getNumWithDrawals() descending
                                              select account).Take(10);
        Console.WriteLine(printALine() + "Highest withdrew account(s)" + printALine());

        foreach (var account in top10HighestWithdrawalAccounts)
        {
            Console.WriteLine($"Account {account.getAccountNumber()} | WithDrawals:{account.getNumWithDrawals()}");
        }
    }

    public static bool AdminLogin(string adminUsername, int adminPin, string filePath)
    {
        try
        {
            using (StreamReader fileReader = new StreamReader(filePath))
            {
                string lineOfData;
                while (!fileReader.EndOfStream)
                {
                    lineOfData = fileReader.ReadLine()!;
                    string[] fileData = lineOfData.Split(",");

                    string fileAdminUsername = fileData[0];
                    int fileAdminPin = int.Parse(fileData[1]);

                    if (adminUsername == fileAdminUsername && adminPin == fileAdminPin)
                    {
                        return true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nAn error occurred: {ex.Message}\n");
        }
        return false;
    }

    public static string printALine()
    {
        return "\n_____________________________________\n";
    }
}