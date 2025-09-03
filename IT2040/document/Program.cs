namespace document;
class Program
{
    static void Main(string[] args)
    {
        Boolean continueEntireProgram = true;
        while(continueEntireProgram)
        {
            Console.WriteLine("Document\n");
            Boolean keepGoing = true;
            string nameofDoc;
            while(keepGoing)
            {
                try
                {
                    Console.WriteLine("Enter the name of the document");
                    nameofDoc = Console.ReadLine()!;
                    bool empty = string.IsNullOrWhiteSpace(nameofDoc);

                    if(empty)
                    {
                        throw new Exception();
                    }
                    keepGoing = false;

                    Boolean continueLoop = true;
                    while(continueLoop)
                    {
                        if(nameofDoc.EndsWith(".txt")){
                            break;
                        }
                        else
                        {
                            nameofDoc+= ".txt";
                        }

                        StreamWriter fileWriter = new StreamWriter(nameofDoc);
                        string input;
                        
                        try
                        {
                            Console.WriteLine("Enter the content to be written to the document");
                            input = Console.ReadLine()!;
                            fileWriter.WriteLine(input);
                            fileWriter.Close();
                            
                            string[] words = input.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                            int wordCount = words.Length;
                            Console.WriteLine($"Document saved successfully, it contains {wordCount} words");
                        }
                        catch(Exception error)
                        {
                            Console.WriteLine($"exception: {error.Message}");
                            Console.WriteLine("document failed to save");
                        }
                        finally
                        {
                            fileWriter?.Close();
                        }
                    }
                    
                }
                catch(Exception)
                {
                    Console.WriteLine("Error: Enter a document name");
                }  

                Console.WriteLine("Do you wish to continue y/n");

                Boolean isValid = false;
                do
                {
                    try
                    {
                        char response = char.Parse(Console.ReadLine()!);

                        switch(response)
                        {
                            case 'y':
                                continueEntireProgram = true;
                                isValid = true;
                                break;
                            case 'n':
                                continueEntireProgram = false;
                                isValid = true;
                                break;
                            default:
                                throw new Exception();
                        }
                      
                    }
                    catch(Exception)
                    {
                        Console.WriteLine("enter a valid response");
                    }
                } 
                while (!isValid);
            }
        }
    }
}
