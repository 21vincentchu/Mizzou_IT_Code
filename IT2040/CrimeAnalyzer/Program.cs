namespace CrimeAnalyzer;
class Program
{
    static void Main(string[] args)
    {
        try
        {
            if (args.Length == 2)
            {
                Console.WriteLine("Number of arguments:" + args.Length);
                foreach (var arg in args)
                {
                    Console.WriteLine($"arg at = " + arg);
                }

                string CSVfile = args[0];
                string reportFile = args[1];
                try
                {
                    List<Crime> crimeList = CrimeDataLoader.loadCrimes(CSVfile);
                    StreamWriter fileWriter = new StreamWriter(reportFile);
                    try
                    {
                        //What is the range of years included in the data + how many years of data are included
                        var rangeOfyears = from crimestat in crimeList select crimestat.getYear();

                        fileWriter.WriteLine($"{rangeOfyears.Min()}-{rangeOfyears.Max()} ({rangeOfyears.Count()} years)");

                        //what years is the numbers of murders per year less than 15,000
                        var murderYears = from crimestat in crimeList
                                          where crimestat.getMurder() < 15000
                                          select crimestat.getYear();

                        fileWriter.WriteLine($"years murders per year < 15,000: ");
                        foreach (int year in murderYears)
                        {
                            fileWriter.Write($"{year} ");
                        }
                        fileWriter.WriteLine();

                        //years where robbers is more than 500,000. Include the year, and associated robberies for that year. 
                        var robberyYears = from crimestat in crimeList
                                           where crimestat.getRobbery() > 500000
                                           select new { Year = crimestat.getYear(), robbery = crimestat.getRobbery() };

                        foreach (var result in robberyYears)
                        {
                            fileWriter.WriteLine($"Year: {result.Year} = Robberies: {result.robbery} ");
                        }

                        //What is the violent crime per capita rate for 2010?
                        var capitaRate2010 = from crimestat in crimeList
                                             where crimestat.getYear() == 2010
                                             select new
                                             {
                                                 Value1 = crimestat.getViolentCrime(),
                                                 Value2 = crimestat.getPopulation(),
                                                 MurderRate = (decimal)crimestat.getViolentCrime() / crimestat.getPopulation()
                                             };

                        foreach (var result in capitaRate2010)
                        {
                            fileWriter.WriteLine($"Violent Crime per capita rate (2010):{result.MurderRate}");
                        }

                        //Average murder per year all years
                        var averageMurderAll = (from crimestat in crimeList
                                                select crimestat.getMurder())
                                               .Average();
                        fileWriter.WriteLine($"Average murder per year (all years): {averageMurderAll}");

                        //Average murder per year (1994-1997)
                        var averageMurder1994_1997 = (from crimestat in crimeList
                                                      where crimestat.getYear() >= 1994 && crimestat.getYear() <= 1997
                                                      select crimestat.getMurder())
                                                     .Average();
                        fileWriter.WriteLine($"Average murder per year(1994-1997): {averageMurder1994_1997}");

                        //Average murder per year (2010-2014)
                        var averageMurder2010_2014 = (from crimestat in crimeList
                                                      where crimestat.getYear() >= 2010 && crimestat.getYear() <= 2014
                                                      select crimestat.getMurder())
                                                     .Average();
                        fileWriter.WriteLine($"Average murder per year(2010-2014): {averageMurder2010_2014}");

                        //Minimum thefts for year(1999-2004)
                        var minimumThefts1999_2004 = (from crimestat in crimeList
                                                      where crimestat.getYear() >= 1999 && crimestat.getYear() <= 2004
                                                      select crimestat.getTheft())
                                                     .Min();
                        fileWriter.WriteLine($"Average murder per year(1994-1997): {minimumThefts1999_2004}");

                        //Minimum thefts for year(1999-2004)
                        var maximumthefts1999_2004 = (from crimestat in crimeList
                                                      where crimestat.getYear() >= 1999 && crimestat.getYear() <= 2004
                                                      select crimestat.getTheft())
                                                     .Max();
                        fileWriter.WriteLine($"Average murder per year(1994-1997): {maximumthefts1999_2004}");

                        //Max motor vehicle thefts through all years
                        var maxMVT = (from crimestat in crimeList
                                      orderby crimestat.getMotorVehicleThieft() descending
                                      select crimestat.getYear())
                                    .First();
                        fileWriter.WriteLine($"Year of highest number of motor vehicle thefts: {maxMVT}");
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine($"Exception: {err.Message}");
                    }
                    finally
                    {
                        fileWriter?.Close();
                    }
                }
                catch (Exception)
                {
                    Console.Write("Enter a valid CSV file name");
                }
            }
            else
            {
                throw new Exception("you have inputed too many arguments. first is CrimeData path, second is report path");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
