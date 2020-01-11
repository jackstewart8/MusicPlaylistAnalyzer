using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MusicPlaylistAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("MusicPlaylistAnalyzer <Music_Playlist_File_Path> <Output_File_Path>");
                Environment.Exit(1);

                string SampleMusicPlaylist = args[0];
                string reportFile = args[1];

                if (!File.Exists(reportFile))
                    using (StreamWriter newReport = new StreamWriter(reportFile))
                        File.Create(reportFile);
                else
                    using (StreamWriter newReport = new StreamWriter(reportFile))
                        newReport.WriteLine(string.Empty);
            }

            RunText();
        }
        public static void printReport(IEnumerable<InfoLine> x)
        {
            foreach (var line in x)
            {
                Console.WriteLine(line.ToString());
            }
        }
        public static void RunText()
        {
            List<InfoLine> musicList = System.IO.File.ReadAllLines(@"/Users/jackstewart/Desktop/MusicFinal/MusicAnalyzer/MusicAnalyzer/SampleMusicPlaylist.txt")
                .Select(line => new InfoLine(line.Split('\t')))
                .ToList();


            musicList.RemoveAt(0);
            var newList = musicList;

            var Plays200 = musicList.Where(song => song.songPlays >= 200).ToList();

            var GenreAlt = musicList.Where(song => song.songGenre == "Alternative").ToList();

            var GenreHipRap = musicList.Where(song => song.songGenre == "Hip-Hop/Rap").ToList();

            var AlbumFish = musicList.Where(song => song.songAlbum == "Welcome to the Fishbowl").ToList();

            var Age1970 = musicList.Where(song => song.songYear < 1970).ToList();

            var LongNames = musicList.Where(song => song.songName.Length > 85).ToList();

            var LongTime = musicList.OrderByDescending(song => song.songTime).First();

            Console.WriteLine("Music Playlist Report \nSongs that received 200 or more plays:");
            printReport(Plays200);
            Console.WriteLine("Number of Alternative songs:" + GenreAlt.Count);
            Console.WriteLine("Number of Hip-Hop/Rap songs:" + GenreHipRap.Count);
            Console.WriteLine("Songs from the album Welcome to the Fishbowl");
            printReport(AlbumFish);
            Console.WriteLine("Songs from before 1970:");
            printReport(Age1970);
            Console.WriteLine("Song names longer than 85 characters:");
            printReport(LongNames);
            Console.WriteLine("Longest song: " + LongTime);

        }
    }

    public class InfoLine
    {
        public string songName;
        public string songArtist;
        public string songAlbum;
        public string songGenre;
        public int songSize;
        public int songTime;
        public int songYear;
        public int songPlays;
        int checkSize = 0;
        int checkTime = 0;
        int checkYear = 0;
        int checkPlays = 0;

        public override string ToString()
        {
            return String.Format("Name: {0}, Artist: {1}, Album: {2}, Genre: {3}, Size: {4}, Time: {5}, Year: {6}, Plays: {7}",
                this.songName, this.songArtist, this.songAlbum, this.songGenre, this.songSize, this.songTime, this.songYear, this.songPlays);

        }

        public InfoLine(string[] test)
        {
            this.songName = test[0];
            this.songArtist = test[1];
            this.songAlbum = test[2];
            this.songGenre = test[3];

            int parsedNumber;
            bool success4 = Int32.TryParse(test[4], out parsedNumber);
            this.songSize = success4 ? parsedNumber : checkSize++;

            if (checkSize >= 2)
            {
                throw new Exception("Wrong size");
            }

            if (success4 == false)
            {
                checkSize++;
            }

            bool success5 = Int32.TryParse(test[5], out parsedNumber);
            this.songTime = success4 ? parsedNumber : checkTime++;

            if (checkTime >= 2)
            {
                throw new Exception("Wrong time");
            }

            if (success4 == false)
            {
                checkTime++;
            }

            bool success6 = Int32.TryParse(test[6], out parsedNumber);
            this.songYear = success4 ? parsedNumber : checkYear++;

            if (checkYear >= 2)
            {
                throw new Exception("Wrong year");
            }

            if (success4 == false)
            {
                checkYear++;
            }

            bool success7 = Int32.TryParse(test[7], out parsedNumber);
            this.songPlays = success4 ? parsedNumber : checkPlays++;

            if (checkPlays >= 2)
            {
                throw new Exception("Wrong polays");
            }

            if (success4 == false)
            {
                checkPlays++;
            }

        }
    }
}



