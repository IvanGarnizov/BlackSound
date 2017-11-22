namespace BlackSound.Client.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Models;

    public static class Validator
    {
        public static bool SongExists(int id, List<Song> songs, out Song song)
        {
            song = songs
                .FirstOrDefault(s => s.Id == id);

            if (song == null)
            {
                Console.WriteLine(Messages.SongNoExist(id));

                return false;
            }

            return true;
        }

        public static bool PlaylistExistsId(int id, int userId, List<Playlist> playlists, out Playlist playlist)
        {
            playlist = playlists
                .FirstOrDefault(p => p.Id == id && p.UserId == userId);

            if (playlist == null)
            {
                Console.WriteLine(Messages.PlaylistNoExistOrNoOwner(id));

                return false;
            }

            return true;
        }

        public static bool PlaylistExistsName(string name, List<Playlist> playlists)
        {
            var playlist = playlists
                .FirstOrDefault(p => p.Name == name);

            if (playlist != null)
            {
                Console.WriteLine(Messages.PlaylistExists);

                return true;
            }

            return false;
        }

        public static bool UserExists(string email, List<User> users)
        {
            var user = users
                .FirstOrDefault(u => u.Email == email);

            if (user != null)
            {
                Console.WriteLine(Messages.UserExists);

                return true;
            }
            
            return false;
        }

        public static bool IsInteger(string value, out int number, string name)
        {
            if (int.TryParse(value, out number))
            {
                return true;
            }

            Console.WriteLine(Messages.NoInteger(name));

            return false;
        }
    }
}
