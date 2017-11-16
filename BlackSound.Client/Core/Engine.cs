namespace BlackSound.Client.Core
{
    using BlackSound.Client.Core.Controllers;
    using System;
    using System.Linq;

    public class Engine
    {
        private string input;
        private SongsController songsController;
        private PlaylistsController playlistsController;
        private UsersController usersController;

        public Engine()
        {
            this.songsController = new SongsController();
            this.playlistsController = new PlaylistsController();
            this.usersController = new UsersController();
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
                        this.songsController.Create(arguments);

                        break;
                    case "ReadSongs":
                        this.songsController.Read();

                        break;
                    case "UpdateSong":
                        this.songsController.Update(arguments);

                        break;
                    case "DeleteSong":
                        this.songsController.Delete(arguments);

                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
