namespace FinalProject;
public class CreateAccount
{
    public static void DisplayMenu(List<Account> accountList)
    {
        try
        {
            Console.WriteLine("Create Account Menu:");
            Console.WriteLine("Provide First name");
            string firstName = Console.ReadLine()!;
            bool isFirstnameValid = isNamevalid(firstName);

            if (isFirstnameValid == true) //checks first name 
            {
                Console.WriteLine("provide last name");
                string lastName = Console.ReadLine()!;
                bool isLastNamevalid = isNamevalid(lastName);

                if (isLastNamevalid == true) //checks last name only if firstname is valid
                {
                    Console.WriteLine("Provide a 4 digit pin");
                    int pin = int.Parse(Console.ReadLine()!);
                    bool isPinValid = AccountLogin.validateNumbers(pin, 1000, 9999, "\nERROR: Invalid PIN format. It should be a 4-digit number.\n");

                    if (isPinValid == true) //checks pin only if pin is valid
                    {
                        bool isValidInput = false;
                        while (!isValidInput) //encapsulated in a while loop, if they don't press 1 or 2, it'll reprompt
                        {
                            accountType accountType;
                            Console.WriteLine("Enter 1 for Savings or 2 for Checking:");
                            string userInput = Console.ReadLine()!;

                            string newAccountNumberString = GenerateAccountNumber(accountList);
                            long newAccountNumber = long.Parse(newAccountNumberString);
                            switch (userInput)
                            {
                                case "1":
                                    accountType = accountType.Savings;
                                    Account newAccountSaving = new Account(newAccountNumber, pin, firstName, lastName, 100, 1, 0, accountType);
                                    addAccountInCSV(newAccountSaving, "account_data.csv");
                                    isValidInput = true;
                                    break;
                                case "2":
                                    accountType = accountType.Checking;
                                    Account newAccountChecking = new Account(newAccountNumber, pin, firstName, lastName, 100, 1, 0, accountType);
                                    addAccountInCSV(newAccountChecking, "account_data.csv");
                                    isValidInput = true;
                                    break;
                                default:
                                    Console.WriteLine("Invalid input. Please enter 1 for Savings or 2 for Checking.");
                                    break;
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
    public static bool isNamevalid(string name)
    {
        try
        {
            // Check if the input contains numeric characters
            foreach (char c in name)
            {
                if (char.IsDigit(c))
                {
                    throw new ArgumentException("The name contains invalid characters.");
                }
            }

            return true; //will return true is the characters are not ints
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
            return false; //name isn't valid b/c it has digits
        }
        catch (Exception)
        {
            Console.WriteLine("ERROR: Please enter a valid name.");
            return false; //covers anything else
        }
    }

    public static string GenerateAccountNumber(List<Account> accountList)
    {
        Random RandomGenerator = new Random();
        string generatedNumber = "";
        bool isUnique = false;
        while (!isUnique)
        {
            int part1 = RandomGenerator.Next(10000, 99999); // Generates the first 5-digit number
            int part2 = RandomGenerator.Next(10000, 99999);
            generatedNumber = $"183977{part1}{part2}";

            isUnique = true;

            foreach (var account in accountList)
            {
                if (account.getAccountNumber().ToString() == generatedNumber)
                {
                    isUnique = false;
                    break;
                }
            }
        }
        return generatedNumber;
    }

    static void addAccountInCSV(Account newAccount, string filePath)
    {
        try
        {
            string accountDetails = $"{newAccount.getAccountNumber()},{newAccount.getPin()},{newAccount.getFirstName()},{newAccount.getLastName()},{newAccount.getBalance()},{newAccount.getNumDeposits()},{newAccount.getNumWithDrawals()},{newAccount.GetAccountType()}\n";
            File.AppendAllText(filePath, accountDetails);
            Console.WriteLine("\nAccount added successfully.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while adding the account: {ex.Message}");
        }
    }
}