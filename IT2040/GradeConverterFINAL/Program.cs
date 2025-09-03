namespace GradeConverter;
class Program
{
    static void Main(string[] args)
    {
        Boolean more = true;
        while(more)
        {
            //get user name
            Console.WriteLine("Enter your first and last name");
            string name = Console.ReadLine()!;
            
            //start the program
            Console.WriteLine("---------GRADE CONVERTER PROGRAM----------");

            float numberOfgrades = numOfgrades();

            //put valid scores into a list
            List<float> nums = new List<float>();
            for(int i = nums.Count; nums.Count < numberOfgrades; i++)
            {
                try
                {
                    Console.WriteLine("Enter the score to be converted");
                    float score = float.Parse(Console.ReadLine()!);
                    if(score >= 0.0f && score <= 100.0f)
                    {
                        nums.Add(score);
                    }
                    else{
                        throw new Exception();
                    }
                }
                catch(Exception)
                {
                    Console.WriteLine("enter a valid number");
                }
            }

            float avg = nums.Average();
            
            Console.WriteLine("\nCONVERTED GRADES\n________________________");
            for(int index = 0; index <= nums.Count-1; index++)
            {
               string letterGrade = convertGrade(nums[index]);
               Console.WriteLine($"{nums[index]} ==> {letterGrade}");
            }

            //grade stats
            Console.WriteLine($"\nname:{name}\nNumber of grades {numberOfgrades}\nAverage Grade: {avg} ==> {convertGrade(avg)}");
         
            //continue program?
            Console.WriteLine("do you wish to continue? (y/n)");
            string response = Console.ReadLine()!;
            if(response == "y")
            {
                more = true;
            }
            else
            {
                more = false;
            }
        } 
    }
    static string convertGrade(float grade)
    {
        string letterGrade;

        switch(grade)
        {
            case >=90.0f:
                letterGrade = "A";
                
                break;
            case >=80.0f:
                letterGrade = "B";
                
                break;
            case >=70.0f:
                letterGrade = "C";
                break;
            case >=60.0f:
                letterGrade = "D";
                break;
            default:
                letterGrade = "F";
                break;
        }
        return letterGrade;
    }

    static int numOfgrades()
    {
        Boolean keepGoing = true;
        int grades = 0;
        while(keepGoing)
        {
            try
            {
                Console.WriteLine("who many grades do you need to convert?");
                grades = int.Parse(Console.ReadLine());

                if(grades < 0)
                {

                    Console.WriteLine("Must be a postivie number");
                    continue;
                }
                keepGoing = false;
            }
            catch(Exception)
            {
                Console.WriteLine("Enter a number");
            }
        }
        return grades;
    }
}