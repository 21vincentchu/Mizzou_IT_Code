namespace AnalyzeMusicPlaylist;
class Program
{
    static void Main(string[] args)
    {
        try
        {
            if (args.Length == 2)
            {
                string musicFile = args[0];
                string reportFile = args[1];
                try
                {
                    List<Music> musicList = MusicDataLoader.loadFile(musicFile);
                    StreamWriter fileWriter = new StreamWriter(reportFile);
                    try
                    {
                        //Songs with over 200 streams
                        var songsOver200Plays = from musicStat in musicList
                                                where musicStat.getPlays() >= 200
                                                select musicStat.ToString();
                        fileWriter.WriteLine("Songs that received 200 or more plays:");
                        foreach (var song in songsOver200Plays)
                        {
                            fileWriter.WriteLine(song);
                        }
                        
                        //Number of songs in altnerative genre
                        var numSongsInAlternative = (from musicStat in musicList
                                                     where musicStat.getGenre() == "Alternative"
                                                     select musicStat).Count();
                        fileWriter.WriteLine($"\nNumber of Alternative Songs: {numSongsInAlternative}");
                        
                        //number of songs in hip-hop/rap genre
                        var numSongsInHHR = (from musicStat in musicList
                                             where musicStat.getGenre() == "Hip-Hop/Rap"
                                             select musicStat).Count();
                        fileWriter.WriteLine($"\nNumber of Hip-Hop/Rap Songs: {numSongsInHHR}");
                        
                        //songs in the album, "Welcome to the fishbowl"
                        var songsInWelcomeToTheFishBowl = from musicStat in musicList
                                                          where musicStat.getAlbum() == "Welcome to the Fishbowl"
                                                          select musicStat.ToString();
                        fileWriter.WriteLine("Songs from the album, Welcome to the Fishbowl");
                        foreach (var song in songsInWelcomeToTheFishBowl)
                        {
                            fileWriter.WriteLine(song);
                        }
                        
                        //songs before 1970
                        var songsBefore1970 = from musicStat in musicList
                                              where musicStat.getYear() <= 1970
                                              select musicStat.ToString();
                        fileWriter.WriteLine("Songs before 1970");
                        foreach (var song in songsBefore1970)
                        {
                            fileWriter.WriteLine(song);
                        }

                        //songs more then 85 characters long
                        var songNamemoreThan85Char = from musicStat in musicList
                                                     where musicStat.getName().Length > 85
                                                     select musicStat.ToString();
                        fileWriter.WriteLine("Song name more than 85 characters long");
                        foreach (var song in songNamemoreThan85Char)
                        {
                            fileWriter.WriteLine(song);
                        }

                        //longest song times
                        var longestSongTime = from musicStat in musicList
                                              where musicStat.getTime() == (from otherMusicStat in musicList select otherMusicStat.getTime()).Min()
                                              select musicStat.ToString();
                        fileWriter.WriteLine("The longest song(s) by time length of song");
                        foreach (var song in longestSongTime)
                        {
                            fileWriter.WriteLine(song);
                        }

                        //every unique genre
                        var uniqueGenres = (from musicStat in musicList
                                            group musicStat by musicStat.getGenre() into genres
                                            select genres.Key).ToList();
                        fileWriter.WriteLine("------------Every unique song genre------------");
                        foreach (var genre in uniqueGenres)
                        {
                            fileWriter.WriteLine(genre);
                        }

                        //Yearly number of songs
                        fileWriter.WriteLine("------------Yearly Number of Songs------------");
                        var songsPerYear = (from musicStat in musicList
                                            group musicStat by musicStat.getYear() into years
                                            select new
                                            {
                                                Year = years.Key,
                                                SongCount = years.Count()
                                            }).ToList();
                        foreach (var years in songsPerYear)
                        {
                            string formattedOutput = string.Format("{0}: {1}", years.Year, years.SongCount);
                            fileWriter.WriteLine(formattedOutput);
                        }
 
                        //Total plays per year
                        var totalPlaysPerYear = (from musicStat in musicList
                                                group musicStat by musicStat.getYear() into playsPerYear
                                                select new
                                                {
                                                    Year = playsPerYear.Key,
                                                    totalPlays = (from musicStat in playsPerYear
                                                                  select musicStat.getPlays()).Sum()
                                                }).ToList();
                        fileWriter.WriteLine("------------Total Plays Per Year------------");
                        foreach(var plays in totalPlaysPerYear)
                        {
                            string formattedOutPut = string.Format("{0}: {1}", plays.Year, plays.totalPlays);
                            fileWriter.WriteLine(formattedOutPut);
                        }

                        //A list of every unique artist
                        var uniqueArtists = (from musicStat in musicList
                                             group musicStat by musicStat.getArtist() into artists
                                             select artists.Key).ToList();
                        fileWriter.WriteLine("------------Every Single Unique Artist In The Playlist------------");
                        foreach(var artists in uniqueArtists)
                        {
                            fileWriter.WriteLine(artists);
                        }       
                    }
                    catch (Exception err)
                    {
                        fileWriter.WriteLine($"Exception: {err.Message}");
                    }
                    finally
                    {
                        fileWriter?.Close();
                    }
                }
                catch (Exception)
                {
                    Console.Write("Enter a valid file name");
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