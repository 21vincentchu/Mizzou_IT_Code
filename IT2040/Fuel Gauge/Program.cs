using System.Text.RegularExpressions;
namespace Fuel_Gauge;
class Program
{
    static void Main(string[] args)
    {
        Boolean keepGoing = true;

        while(keepGoing)
        {
            String end = "end";
            Console.WriteLine("Fraction");
            string pattern = @"^\d+/\d+$";
            String input = Console.ReadLine()!;
            
            if(String.Equals(end, input, StringComparison.OrdinalIgnoreCase) == true)
            {
                Environment.Exit(1);
            }   

            try
            {
                string [] fractionParts = input.Split("/");

                float x = float.Parse(fractionParts[0]);
                float y = float.Parse(fractionParts[1]);

                if(Regex.IsMatch(input, pattern) && x < y && y != 0){
                    String convertedInput = Convert(x, y);
                    Console.WriteLine($"{convertedInput}");
                }
            }
            catch(Exception){ }
        }
    }
    public static string Convert(float x, float y)
    {
        float percent = x / y * 100;
        string formattedFloat = percent.ToString("N0");

        if(x == 99 && y == 100){
            return "F";
        }else if(x == 1 && y == 100){
            return "E";
        }else{
            return formattedFloat + "%";
        }
    }   
}