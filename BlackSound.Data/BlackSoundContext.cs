namespace BlackSound.Data
{
    using System;
    using System.IO;

    using Models;

    public class BlackSoundContext
    {
        private const string SongsPath = "../../../BlackSound.Data/songs.txt";

        public void CreateSong(Song song)
        {
            string songString = String.Empty;

            if (!File.Exists(SongsPath))
            {
                songString = song.ToString();
            }
            else
            {
                songString = Environment.NewLine + song.ToString();
            }

            File.AppendAllText(SongsPath, songString);
        }

        public string GetSongs()
        {
            if (File.Exists(SongsPath))
            {
                return File.ReadAllText(SongsPath);
            }

            return "";
        }
    }
}
