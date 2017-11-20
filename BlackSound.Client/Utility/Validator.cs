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
                Console.WriteLine($"Song with id {id} doesn't exist.");

                return false;
            }

            return true;
        }

        public static bool PlaylistExists(int id, int userId, List<Playlist> playlists, out Playlist playlist)
        {
            playlist = playlists
                .FirstOrDefault(p => p.Id == id && p.UserId == userId);

            if (playlist == null)
            {
                Console.WriteLine($"Playlist with id {id} doesn't exist or you're not the owner.");

                return false;
            }

            return true;
        }

        public static bool IsInteger(string value, out int number, string name)
        {
            if (int.TryParse(value, out number))
            {
                return true;
            }

            Console.WriteLine($"{name} is not an integer.");

            return false;
        }
    }
}
