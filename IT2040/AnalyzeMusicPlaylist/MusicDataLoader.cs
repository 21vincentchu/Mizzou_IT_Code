namespace AnalyzeMusicPlaylist;
public class MusicDataLoader
{
    public static List<Music> loadFile(String file)
    {
        List<Music> dataList = new List<Music>();
        using (StreamReader fileReader = new StreamReader(file))
        {
            int lineNumber = 0;
            int piecesOfData = 8;

            string lineOfData = fileReader.ReadLine()!;

            while (!fileReader.EndOfStream)
            {
                lineOfData = fileReader.ReadLine()!;
                lineNumber++;

                string[] fileData = lineOfData.Split('\t');

                //check if data is in the right format
                if (fileData.Length != piecesOfData)
                {
                    string errorMessage = $"Row {lineNumber} contains {fileData.Length} pieces of data. It should contain {piecesOfData} pieces of data ";
                    Console.WriteLine(errorMessage);
                    continue;
                }
                try
                {
                    string name = fileData[0].ToString();
                    string artist = fileData[1].ToString();
                    string album = fileData[2].ToString();
                    string genre = fileData[3].ToString();
                    int size = int.Parse(fileData[4]);
                    int time = int.Parse(fileData[5]);
                    int year = int.Parse(fileData[6]);
                    int plays = int.Parse(fileData[7]);
             
                    dataList.Add(new Music(name,artist, album, genre, size, time, year, plays));
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