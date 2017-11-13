namespace BlackSound.Client.Core
{
    using System;
    using System.Collections.Generic;

    using Data;

    using Models;

    class BlackSoundController
    {
        private BlackSoundContext context;

        public BlackSoundController()
        {
            this.context = new BlackSoundContext();
        }

        public void CreateSong(List<string> arguments)
        {
            string title = arguments[0];
            int year = int.Parse(arguments[1]);
            var song = new Song()
            {
                Title = title,
                Year = year
            };

            this.context.CreateSong(song);
        }

        public void ReadSongs()
        {
            var songs = this.context.GetSongs();

            Console.WriteLine(songs);
        }
    }
}
