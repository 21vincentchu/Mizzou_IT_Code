namespace DocumentMerger;
class Program
{
    static void Main(string[] args)
    {
        while(true)
        {
            Console.WriteLine("Document merger\n");

            //call GetDocumentName to make and return a list of file names
            List<string> fileNames = GetDocumentName();  

            //make the conbined file with the combined film name
            Console.WriteLine("this will be the combined file name");
            string combinedDocument = MergeDocumentNames(fileNames);
            using(File.Create(combinedDocument)){}

            //Write the content to the combined file
            Console.WriteLine($"Enter the content to be written to {combinedDocument}");
            string docText = Console.ReadLine()!;
            WriteContentToDocument(combinedDocument, docText);

            //prompt if they want to continue
            Console.WriteLine("To create another combined txt file type 'y'. Type any other key to exit");
            string loopAgain = Console.ReadLine()!;
            if (!loopAgain.Equals("y")){
                break;
            }  
        }
    }

    static List<string> GetDocumentName(){
        List<string> stringList = new List<string>();
        string docName;
        while(true){
            Console.WriteLine("Enter the name(s) of the file(s) you want to combine. press enter to indicate you are done");
            docName = Console.ReadLine()!;
            stringList.Add(CheckDocumentName(docName));
            
            if(docName == ""){
                break;
            }
        }
        return stringList;
    }
    static string CheckDocumentName(string documentName){
        if(documentName.EndsWith(".txt")){
            return documentName;
        }else{
            return documentName + ".txt";
        }
    }
    static string MergeDocumentNames(List<string> myList){
        string combinedString = "";

        foreach(string str in myList){
            combinedString += str[..^4];
        }

        Console.WriteLine($"Enter a new file name or press enter to default to {CheckDocumentName(combinedString)})");
        string combinedFileName = Console.ReadLine()!;

        if(combinedFileName == ""){
            return CheckDocumentName(combinedString);
        }else{
            return CheckDocumentName(combinedFileName);
        }
    }
    static int GetWordCount(string document){
        string[] words = document.Split(" ");
        return words.Length;
    }
    static void WriteContentToDocument(string documentName, string documentText){
        int numberOfWords = GetWordCount(documentText);
        StreamWriter sw = new StreamWriter(documentName);
        try{
            sw.WriteLine(documentText);
            sw.Close();
        }catch(Exception err){
            //If an exception occurs, output the exception message and exit.
            Console.WriteLine("Exception: " + err.Message);
        }
        finally{
            sw?.Close();
            //If an exception does not occur, output “[filename] was successfully saved.
            Console.WriteLine($"\n{documentName} was successfully saved. The document contains {numberOfWords} words.");
        }
    }
}