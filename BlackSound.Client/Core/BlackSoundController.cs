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

        public void Create(List<string> arguments)
        {
            string title = arguments[0];
            int year = int.Parse(arguments[1]);
            var song = new Song()
            {
                Title = title,
                Year = year
            };

            this.context.CreateSong(song);
            this.context.SaveChanges();
        }

        public void Read()
        {
            Console.WriteLine(this.context.ReadSongs());
        }

        public void Update(List<string> arguments)
        {
            int id = int.Parse(arguments[0]);

            if (this.context.SongExists(id))
            {
                Console.WriteLine($"Song with id {id} exists.");
            }
            else
            {
                Console.WriteLine($"Song with id {id} does not exist.");
            }
        }

        public void Delete(List<string> arguments)
        {
            int id = int.Parse(arguments[0]);

            if (this.context.SongExists(id))
            {
                this.context.DeleteSong(id);
            }
            else
            {
                Console.WriteLine($"Song with id {id} does not exist.");
            }
        }
    }
}
