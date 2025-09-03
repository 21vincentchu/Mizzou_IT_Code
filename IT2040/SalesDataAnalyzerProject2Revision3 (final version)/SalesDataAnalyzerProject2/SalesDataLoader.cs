namespace SalesDataAnalyzerProject2;
public class SalesDataLoader
{
    public static List<Sale> loadFile(String file)
    {
        List<Sale> dataList = new List<Sale>();
        using (StreamReader fileReader = new StreamReader(file))
        {
            int lineNumber = 0;
            int piecesOfData = 11;

            string lineOfData = fileReader.ReadLine()!;

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
                    string invoiceID = fileData[0];
                    char branch = char.Parse(fileData[1]);
                    string city = fileData[2];
                    string customerType = fileData[3];
                    string gender = fileData[4];
                    string productLine = fileData[5];
                    decimal unitPrice = decimal.Parse(fileData[6]);
                    int quantity = int.Parse(fileData[7]);
                    string date = fileData[8];
                    string payment = fileData[9];
                    decimal rating = decimal.Parse(fileData[10]);

                    dataList.Add(new Sale(invoiceID, branch, city, customerType, gender, productLine, unitPrice, quantity, date, payment, rating));
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