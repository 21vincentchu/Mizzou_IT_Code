namespace MealTime;

class Program
{
    static void Main(string[] args)
    {
        float timeAsInt;
        string userTime;
        Console.WriteLine("What time is it?");
        userTime = Console.ReadLine();
        timeAsInt = Convertime(userTime);

        Console.WriteLine($"{timeAsInt}");

        if(timeAsInt >= 7.0 && timeAsInt <= 8.0)
        {
            Console.WriteLine("It's breakfast time!");
        }
        else if(timeAsInt >= 12.0 && timeAsInt <= 13.0)
        {
            Console.WriteLine("It's time for lunch!");
        }
        else if(timeAsInt >= 18.0 && timeAsInt <= 19.0)
        {
            Console.WriteLine("It's time for dinner!");
        }
        else
        {
            Console.WriteLine("It's not time to eat!");
        }
    }
    public static float Convertime(string time)
    {
        string[]timeParts = time.Split(":");

        float hour = int.Parse(timeParts[0]);
        float minutes = int.Parse(timeParts[1]);
        float timeInt = hour + (minutes / 60);

        return timeInt;
    }
}
