namespace CrimeAnalyzer;
public class CrimeDataLoader
{
    public static List<Crime> loadCrimes(String file)
    {
        //create a pet list to return
        List<Crime> crimeList = new List<Crime>();

        //open the csv file
        using (StreamReader fileReader = new StreamReader(file))
        {
            int lineNumber = 0;
            int peicesOfData = 11;

            string lineOfData = fileReader.ReadLine()!;

            //parse the data using the split method
            //read file line by line
            while (!fileReader.EndOfStream)
            {
                //read the next line in the file
                lineOfData = fileReader.ReadLine()!;
                lineNumber++;

                //string array <- split data at the comma
                string[] crimeData = lineOfData.Split(",");

                //check if data is in the right format
                if (crimeData.Length != peicesOfData)
                {
                    string errorMessage = $"Row {lineNumber} contains {crimeData.Length} pieces of data. It should contain {peicesOfData} pieces of data ";
                    Console.WriteLine(errorMessage);
                    continue;
                }

                //get the pieces of data from the string array
                //convert data types where necessary
                try
                {
                    int year = int.Parse(crimeData[0]);
                    int population = int.Parse(crimeData[1]);
                    int violentCrime = int.Parse(crimeData[2]);
                    int murder = int.Parse(crimeData[3]);
                    int rape = int.Parse(crimeData[4]);
                    int robbery = int.Parse(crimeData[5]);
                    int aggravatedAssault = int.Parse(crimeData[6]);
                    int propertyCrime = int.Parse(crimeData[7]);
                    int burglary = int.Parse(crimeData[8]);
                    int theft = int.Parse(crimeData[9]);
                    int motorVehicleTheft = int.Parse(crimeData[10]);
                   
                    crimeList.Add(new Crime(year, population,violentCrime, murder, rape, robbery, aggravatedAssault, propertyCrime, burglary, theft, motorVehicleTheft));
                }
                catch (Exception err)
                {
                    string message = $"There was an error reading the file on line {lineNumber}: {err.Message}";
                    Console.WriteLine(message);
                    continue;
                }
            }
        }
        return crimeList;
    }
}