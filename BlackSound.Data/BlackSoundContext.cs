namespace BlackSound.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    using Models;
    using Newtonsoft.Json;

    public class BlackSoundContext
    {
        private const string UsersPath = "../../../BlackSound.Data/users.json";
        private const string PlaylistsPath = "../../../BlackSound.Data/playlists.json";
        private const string SongsPath = "../../../BlackSound.Data/songs.json";

        private List<Song> songs;

        public BlackSoundContext()
        {
            this.Songs = new List<Song>();
        }

        public List<Song> Songs
        {
            get
            {
                if (File.Exists(SongsPath))
                {
                    return JsonConvert.DeserializeObject<List<Song>>(File.ReadAllText(SongsPath));
                }

                return new List<Song>();
            }

            set
            {
                this.songs = value;
            }
        }

        public void SaveChanges(List<Song> songs = null, List<Playlist> playlists = null, List<User> users = null)
        {
            if (songs != null)
            {
                var json = JsonConvert.SerializeObject(songs, Formatting.Indented);

                File.WriteAllText(SongsPath, json);
            }
            else if (playlists != null)
            {
                var json = JsonConvert.SerializeObject(playlists, Formatting.Indented);

                File.WriteAllText(PlaylistsPath, json);
            }
            else if (users != null)
            {
                var json = JsonConvert.SerializeObject(users, Formatting.Indented);

                File.WriteAllText(UsersPath, json);
            }
        }
    }
}
