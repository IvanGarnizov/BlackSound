namespace BlackSound.Data
{
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

        public List<Song> GetSongs()
        {
            if (File.Exists(SongsPath))
            {
                return JsonConvert.DeserializeObject<List<Song>>(File.ReadAllText(SongsPath));
            }

            return new List<Song>();
        }

        public List<Playlist> GetPlaylists()
        {
            if (File.Exists(PlaylistsPath))
            {
                return JsonConvert.DeserializeObject<List<Playlist>>(File.ReadAllText(PlaylistsPath));
            }

            return new List<Playlist>();
        }

        public List<User> GetUsers()
        {
            if (File.Exists(UsersPath))
            {
                return JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(UsersPath));
            }

            return new List<User>();
        }

        public void SaveChanges(List<Song> songs = null, List<Playlist> playlists = null, List<User> users = null)
        {
            if (songs != null)
            {
                var json = JsonConvert.SerializeObject(songs, Formatting.Indented);

                File.WriteAllText(SongsPath, json);
            }

            if (playlists != null)
            {
                var json = JsonConvert.SerializeObject(playlists, Formatting.Indented);

                File.WriteAllText(PlaylistsPath, json);
            }

            if (users != null)
            {
                var json = JsonConvert.SerializeObject(users, Formatting.Indented);

                File.WriteAllText(UsersPath, json);
            }
        }

        public List<Song> GetSongsForPlaylist(int playlistId)
        {
            var playlist = this.GetPlaylists()
                .First(p => p.Id == playlistId);
            var songs = new List<Song>();

            foreach (var songId in playlist.SongIds)
            {
                var song = this.GetSongs()
                    .First(s => s.Id == songId);

                songs.Add(song);
            }

            return songs;
        }
    }
}
