namespace FinalProject;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to bank");

        List<Account> accountList = AccountDataLoader.loadFile("account_data.csv");

        while (true)
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Account login");
            Console.WriteLine("2. Create Account");
            Console.WriteLine("3. Administrator login");
            Console.WriteLine("4. Quit");

            Console.Write("Enter the number of your choice: ");
            string userInput = Console.ReadLine()!;

            switch (userInput)
            {
                case "1":
                    AccountLogin.DisplayMenu(accountList);
                    break;
                case "2":
                    CreateAccount.DisplayMenu(accountList);
                    break;
                case "3":
                    AdministratorLogin.DisplayMenu(accountList); // Pass accountList
                    break;
                case "4":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid input. Please enter a valid option number.");
                    break;
            }
        }
    }
}
