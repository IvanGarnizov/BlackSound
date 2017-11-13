namespace BlackSound.Client.Core
{
    using System;
    using System.Linq;

    public class Engine
    {
        private string input;
        private BlackSoundController controller;

        public Engine()
        {
            this.controller = new BlackSoundController();
        }

        public void Run()
        {
            this.input = Console.ReadLine();

            while (input != "stop")
            {
                var arguments = input.Split(' ').ToList();
                string command = arguments[0];

                arguments.RemoveAt(0);

                switch (command)
                {
                    case "CreateSong":
                        this.controller.CreateSong(arguments);

                        break;
                    case "ReadSongs":
                        this.controller.ReadSongs();

                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
