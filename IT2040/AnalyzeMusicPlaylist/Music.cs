namespace AnalyzeMusicPlaylist;
public class Music
{
    private string name, artist, album, genre;
    private int size, time, year, plays;

    public Music(string name, string artist, string album, string genre, int size, int time, int year, int plays)
    {
        this.name = name;
        this.artist = artist;
        this.album = album;
        this.genre = genre;
        this.size = size;
        this.time = time;
        this.year = year;
        this.plays = plays;
    }
    public string getName()
    {
        return name;
    }

    public string getArtist()
    {
        return artist;
    }
    public string getAlbum()
    {
        return album;
    }
    public string getGenre()
    {
        return genre;
    }
    public int getSize()
    {
        return size;
    }
    public int getTime()
    {
        return time;
    }
    public int getYear()
    {
        return year;
    }
    public int getPlays()
    {
        return plays;
    }

    override public string ToString()
    {
	    return String.Format("Name: {0}, Artist: {1}, Album: {2}, Genre: {3}, Size: {4}, Time: {5}, Year: {6}, Plays: {7}", name, artist, album, genre, size, time, year, plays);
    }
}