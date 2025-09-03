namespace VendingMachine;
class Program
{
    static void Main(string[] args)
    {
        int snack = 50;

        while(snack > 0)
        {
            try
            {
                Console.WriteLine($"amount due {snack}");
                Console.WriteLine("insert a coin");
                var coin = Console.ReadLine();
                int userAmount = int.Parse(coin);
                
                if(userAmount == 1 || userAmount == 5 || userAmount == 10 || userAmount == 25)
                {
                    snack -= userAmount;
                }
                else
                {
                    continue;
                }
            }
            catch(Exception)
            {
                continue;
            }         
        }
        if(snack < 0)
        {
            Console.WriteLine($"You owed {snack * -1}");
        }
    }
}
