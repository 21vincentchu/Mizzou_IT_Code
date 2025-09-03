namespace FinalProject;

public class AccountDataLoader
{
    public static List<Account> loadFile(String file)
    {
        List<Account> dataList = new List<Account>();
        using (StreamReader fileReader = new StreamReader(file))
        {
            int lineNumber = 0;
            int piecesOfData = 8;

            string lineOfData;

            while (!fileReader.EndOfStream)
            {
                lineOfData = fileReader.ReadLine()!;
                lineNumber++;
    
                string[] fileData = lineOfData.Split(",");

                //check if data is in the right format
                if (fileData.Length != piecesOfData)
                {
                    string errorMessage = $"Row {lineNumber} contains {fileData.Length} pieces of data. It should contain {piecesOfData} pieces of data ";
                    Console.WriteLine(errorMessage);
                    continue;
                }
                try
                {
                    long accountNumber = long.Parse(fileData[0]);
                    int pin = int.Parse(fileData[1]);
                    string firstName = fileData[2];
                    string lastName = fileData[3];
                    decimal balance = decimal.Parse(fileData[4]);
                    int numDeposits = int.Parse(fileData[5]);
                    int numWithdrawals = int.Parse(fileData[6]);
                    string accountType = fileData[7];

                    if(accountType == "Savings")
                    {
                        dataList.Add(new CheckingAccount(accountNumber, pin, firstName, lastName, balance, numDeposits, numWithdrawals));
                    }
                    else
                    {
                        dataList.Add(new SavingsAccount(accountNumber, pin, firstName, lastName, balance, numDeposits, numWithdrawals));
                    }
                }
                catch (Exception err)
                {
                    string message = $"There was an error reading the file on line {lineNumber}: {err.Message}";
                    Console.WriteLine(message);
                    continue;
                }
            }
        }
        return dataList;
    }
}