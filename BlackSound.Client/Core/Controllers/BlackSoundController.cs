namespace BlackSound.Client.Core.Controllers
{
    using System;
    using System.Collections.Generic;

    using Data;

    using Models;

    class BlackSoundController
    {
        public BlackSoundController()
        {
            this.Context = new BlackSoundContext();
        }

        protected BlackSoundContext Context { get; set; }

        protected void SaveChanges(List<Song> songs = null, List<Playlist> playlists = null, List<User> users = null)
        {
            this.Context.SaveChanges(songs, playlists, users);
        }

        protected bool IsInteger(string value, out int number, string name)
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
