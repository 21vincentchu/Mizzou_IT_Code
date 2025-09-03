namespace FinalProject;
public class AccountLogin
{
    public static void DisplayMenu(List<Account> accountList)
    {
        try
        {
            //THE ORDER OF VALIDATION
            // 16 digit validation -> checking format -> 4 digit validation -> checking format -> Checking 16 account number AND pin in datafile -> able to log in
            Console.WriteLine("\nEnter your 16 digit account number");
            long accountNum = long.Parse(Console.ReadLine()!);

            bool validAccountNumber = validateNumbers(accountNum, 1_839_770_000_000_000, 1_839_779_999_999_999, "\nERROR: Invalid account number format. It should be a 16-digit number\n");
            //calls the validate function for the account number, with the 16 range numbers. It will return an error with it is not a 16 digit number, will take you back to the main menu

            if (validAccountNumber == true) //Goes to this once ONLY valid account number is in the right format. Doesn't have to be necessary the correct account number just yet
            {
                Console.WriteLine("\nEnter your account 4 digit PIN number:");
                int pin = int.Parse(Console.ReadLine()!);

                bool validPinNumber = validateNumbers(pin, 1000, 9999, "\nERROR: Invalid PIN format. It should be a 4-digit number.\n");
                //calls the validate function for the pin number, within the 4 digit range. it will reuturn an error if it is not a 4 digit number, and will once again take you back to the main menu
                AdministratorLogin.printALine();

                Account loggedInAccount;
                if (validAccountNumber == true && validPinNumber == true) 
                {
                    loggedInAccount = validateAccount(accountNum, pin, accountList); //will check if the account number and pin match up together in the database. Will return an account if valid, null if it isnt

                    while (loggedInAccount != null) 
                    {
                        Console.WriteLine("Account Login Menu:");
                        Console.WriteLine("a. Make a withdrawal");
                        Console.WriteLine("b. Make a deposit");
                        Console.WriteLine("c. Transfer funds to another user account");
                        Console.WriteLine("d. Balance inquiry");
                        Console.WriteLine("e. Back to main menu");


                        Console.Write("Enter the option letter: ");
                        string userInput = Console.ReadLine()!;

                        switch (userInput)
                        {
                            case "a":
                                MakeWithdrawal(loggedInAccount);
                                break;
                            case "b":
                                MakeDeposit(loggedInAccount);
                                break;
                            case "c":
                                Account transferAccount;
                                Console.WriteLine("Enter the 16 digit account number of the transfer account");
                                long transferAccountNumber = long.Parse(Console.ReadLine()!);
                                bool validateTransferAccount = validateNumbers(transferAccountNumber, 1_839_770_000_000_000, 1_839_779_999_999_999, "\nERROR: Invalid account number format. It should be a 16-digit number\n");
                                if (validateTransferAccount == true)
                                {
                                    transferAccount = validateAccount(transferAccountNumber, accountList);
                                    if(transferAccount != null)
                                    {
                                        TransferFunds(loggedInAccount, transferAccount);
                                    }
                                }
                                break;
                            case "d":
                                CheckBalance(loggedInAccount);
                                break;
                            case "e":
                                loggedInAccount = null!;
                                return; // Back to main menu
                            default:
                                Console.WriteLine("ERROR: Invalid input. Please enter a valid option letter.");
                                break;
                        }
                    }
                }
            }

        }
        catch (FormatException)
        {
            Console.WriteLine("\nERROR: Enter valid numbers\n");
        }
    }

    static void MakeWithdrawal(Account loggedInAccount)
    {
        decimal withdrawalAmount; 
        try
        {
            Console.WriteLine("Enter the amount you want to withdrawal");
            withdrawalAmount = decimal.Parse(Console.ReadLine()!);
        }
        catch(FormatException)
        {
            Console.WriteLine("\nERROR: Invalid input format. Please enter a valid number.\n"); //error is it's a string
            return;
        }

        if (withdrawalAmount <= 0 || withdrawalAmount > loggedInAccount.getBalance())
        {
            Console.WriteLine("Invalid amount"); //error if not in range of amount
        }

        loggedInAccount.setBalance(loggedInAccount.getBalance() - withdrawalAmount);

        // Update the CSV file with the new account data
        UpdateAccountInCSV(loggedInAccount, "account_data.csv");
        Console.WriteLine($"Withdrawal of {withdrawalAmount:C} successful. New balance: {loggedInAccount.getBalance():C}");
    }

    static void MakeDeposit(Account loggedInAccount)
    {
        decimal depositAmount; 
        try
        {
            Console.WriteLine("Enter the amount you want to deposit");
            depositAmount = decimal.Parse(Console.ReadLine()!);
        }
        catch(FormatException)
        {
            Console.WriteLine("\nERROR: Invalid input format. Please enter a valid number.\n");
            return;
        }

        if (depositAmount <= 0)
        {
            Console.WriteLine("Invalid amount");
        }

        loggedInAccount.setBalance(loggedInAccount.getBalance() + depositAmount);

        // Update the CSV file with the new account data
        UpdateAccountInCSV(loggedInAccount, "account_data.csv");

        Console.WriteLine($"Withdrawal of {depositAmount:C} successful. New balance: {loggedInAccount.getBalance():C}");
    }

    static void TransferFunds(Account loggedInAccount, Account transferAccount)
    {
       decimal transferAmount; 
        try
        {
            Console.WriteLine($"You will be transfer funds from your account to {transferAccount.getFirstName()} {transferAccount.getLastName()}");
            Console.WriteLine("Enter the amount you want to transfer");
            transferAmount = decimal.Parse(Console.ReadLine()!);
        }
        catch(FormatException)
        {
            Console.WriteLine("\nERROR: Invalid input format. Please enter a valid number.\n"); //Error checking for inputing a string / not a number
            return;
        }
     
        if (transferAmount <= 0 || transferAmount > loggedInAccount.getBalance())
        {
            Console.WriteLine("Invalid amount"); //Error protection for range specified
        }

        loggedInAccount.setBalance(loggedInAccount.getBalance() - transferAmount); 
        UpdateAccountInCSV(loggedInAccount, "account_data.csv"); 
        transferAccount.setBalance(transferAccount.getBalance() + transferAmount);
        UpdateAccountInCSV(transferAccount, "account_data.csv");

        Console.WriteLine($"Withdrawal of {transferAmount:C} successful. {transferAmount:C} will now transfer to {transferAccount.getFirstName()} {transferAccount.getLastName()}. \nYour new balance: {loggedInAccount.getBalance():C}\nTransfer Account ({transferAccount.getFirstName()} {transferAccount.getLastName()}) new balance: {transferAccount.getBalance()}\n");
    }

    static void CheckBalance(Account loggedInAccount)
    {
        Console.WriteLine($"Checking balance of {loggedInAccount.getFirstName()} {loggedInAccount.getLastName()}..");
        decimal Balance = loggedInAccount.getBalance();
        string formattedBalance = Balance.ToString("C");
        Console.WriteLine($"Balance: {formattedBalance}\n");
    }

    public static Account validateAccount(long accountNum, int pin, List<Account> accountList)
    {
        foreach (var account in accountList)
        {
            if (account.getAccountNumber() == accountNum && account.getPin() == pin)
            {
                return account;
            }
        }
        Console.WriteLine("\nERROR:Invalid account number/pin combination\n");
        return null!;
    }

    //Override b/c the transfer of the money does not call for their pin, obviously, assuming they don't know their pin, because they shouldn't
    public static Account validateAccount(long accountNum, List<Account> accountList)
    {
        foreach (var account in accountList)
        {
            if (account.getAccountNumber() == accountNum)
            {
                return account;
            }
        }
        Console.WriteLine("\nERROR: Invalid account number\n");
        return null!;
    }

    public static bool validateNumbers(long accountNum, long range1, long range2, string errorMessage)
    {
        try
        {
            if (accountNum < range1 || accountNum > range2) // validate the range. 
            {
                throw new FormatException(errorMessage); 
            }
            return true; 
        }
        catch (FormatException ex)
        {
            Console.WriteLine(ex.Message); 
        }
        return false; //returns false if the number is out of the range we specified
    }

    static void UpdateAccountInCSV(Account updatedAccount, string filePath)
    {
        try
        {
            string[] lines = File.ReadAllLines(filePath);

            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(','); //Splits the entire account line into array
                string fileAccountNumber = parts[0]; //this is the account number

                string accountNumberToUpdate = updatedAccount.getAccountNumber().ToString(); // Find the line that starts with the account number to be updated
                if (fileAccountNumber == accountNumberToUpdate) 
                {
                    // Replace the existing line with the updated account details
                    string updatedLine = $"{updatedAccount.getAccountNumber()},{updatedAccount.getPin()},{updatedAccount.getFirstName()},{updatedAccount.getLastName()},{updatedAccount.getBalance()},{updatedAccount.getNumDeposits()},{updatedAccount.getNumWithDrawals()},{updatedAccount.GetAccountType()}";
                    lines[i] = updatedLine; //line i, is the line of our account we need to update. We replace that line with the updated line, we just made above. a rewrite.
                    break;
                }
            }
            File.WriteAllLines(filePath, lines); // Write the updated lines back to the file
            Console.WriteLine("\nAccount updated successfully.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while updating the account: {ex.Message}");
        }
    }
}

//hani salim
/*REFERENCES USED:
    Line 132: Needed to read the entire file: https://learn.microsoft.com/en-us/dotnet/api/system.io.file.readalllines?view=net-8.0
    Line 144, i googled how to write all lines again to a file. it does this with writeAllLines. You declare the file path, and then the second part is all the contents you want. 
    Since at the beginning with put all the contents of the file in the array lines, we are just rewriting it. https://learn.microsoft.com/en-us/dotnet/api/system.io.file.writealllines?view=net-8.0
   
*/