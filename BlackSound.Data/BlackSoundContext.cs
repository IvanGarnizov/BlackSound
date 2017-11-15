namespace BlackSound.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    using Models;

    public class BlackSoundContext
    {
        private const string UsersPath = "../../../BlackSound.Data/users.txt";
        private const string PlaylistsPath = "../../../BlackSound.Data/playlists.txt";
        private const string SongsPath = "../../../BlackSound.Data/songs.txt";
        private const string TemporaryPath = "../../../BlackSound.Data/temporary.txt";

        private List<Song> songs;

        public BlackSoundContext()
        {
            this.songs = new List<Song>();
        }

        public List<Song> Songs
        {
            get
            {
                foreach (var record in File.ReadAllLines(SongsPath))
                {
                    string[] parts = record.Split(',');
                    int id = int.Parse(parts[0].Split(' ')[1]);
                    string title = parts[1].Split(' ')[1];
                    int year = int.Parse(parts[2].Split(' ')[1]);

                    this.songs.Add(new Song()
                    {
                        Id = id,
                        Title = title,
                        Year = year
                    });
                }

                return songs;
            }

            set
            {
                this.songs = value;
            }
        }

        public string ReadSongs()
        {
            return String.Join(Environment.NewLine, this.Songs.Select(s => s.ToString()));
        }

        public void CreateSong(Song song)
        {
            this.Songs.Add(song);
        }

        public bool SongExists(int id)
        {
            foreach (var record in File.ReadAllLines(SongsPath))
            {
                string idPair = record.Split(',')[0];
                int songId = int.Parse(idPair.Split(' ')[1]);

                if (id == songId)
                {
                    return true;
                }
            }

            return false;
        }

        public void DeleteSong(int id)
        {
            var song = this.Songs
                .FirstOrDefault(s => s.Id == id);

            this.Songs.Remove(song);
        }

        public void SaveChanges()
        {
            File.WriteAllText(TemporaryPath, this.ReadSongs());

            if (File.Exists(SongsPath))
            {
                File.Delete(SongsPath);
            }

            File.Move(TemporaryPath, SongsPath);
        }
    }
}
