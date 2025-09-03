namespace CsharpBasics;

class Program
{
    static void Main(string[] args)
    {
        const byte sample1 = 0x3a;

        byte sample2 = 58;
        
        int heartRate = 85;
        
        double deposits = 135002796;
        
        const float acceleration = 9.800f;
        
        float mass = 14.6f;
        
        double distance = 129.763001;
        
        bool expensive = true;

        bool lost = true;
        
        int choice = 2;
        
        const char integral = '\u222b';
        
        const string greeting = "hello";
        
        string name = "Karen";

        if(sample1 == sample2)
        {
            Console.WriteLine("The samples are equal");
        }
        else{
            Console.WriteLine("The sampls are not equal");
        }

        if(heartRate >= 40 && heartRate <= 80)
        {
            Console.WriteLine("heart rate is normal");
        } else {
            Console.WriteLine("heart rate is not normal");
        }

        if(deposits >= 100000000)
        {
            Console.WriteLine("you are exceedingly wealthy");
        } else{
            Console.WriteLine("Sorry you are so poor");
        }

        float force = mass * acceleration;
        Console.WriteLine($"Force = {force}");

        Console.WriteLine($"{distance} is the distance");

        if(expensive == true && lost == true){
            Console.WriteLine("I am really sorry! I will get the manager");
        } else{
            Console.WriteLine("Here is a coupon for 10% off");
        }

        switch(choice)
        {
            case 1:
                Console.WriteLine("You chose 1");
                break;
            case 2:
                Console.WriteLine("You chose 2");
                break;
            case 3: 
                Console.WriteLine("You made an unknown choice");
                break;
        }

        Console.WriteLine($"{integral} is an integral");

        for(int i = 5; i <= 10; i++)
        {
            Console.WriteLine($"i = {i}");
        }

        int age = 0;

        while(age < 6)
        {
            Console.WriteLine($"age = {age}");
            age++;
        }

        Console.WriteLine($"{greeting} {name}");
    }
}
