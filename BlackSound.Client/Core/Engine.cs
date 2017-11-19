namespace BlackSound.Client.Core
{
    using System;
    using System.Linq;

    using Core.Controllers;

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
                var arguments = input.Split(',').ToList();
                string command = arguments[0];

                arguments.RemoveAt(0);

                switch (command)
                {
                    case "CreateSong":
                        if (arguments.Count == 3)
                        {
                            if (this.IsAdmin())
                            {
                                this.songsController.Create(arguments);
                            }
                            else
                            {
                                Console.WriteLine("You need to login and be an admin, to be able to publish songs.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Exactly 3 arguments are expected - title, year and artists.");
                        }

                        break;
                    case "ReadSongs":
                        if (arguments.Count == 0)
                        {
                            if (this.IsAdmin())
                            {
                                this.songsController.Read();
                            }
                            else
                            {
                                Console.WriteLine("You need to login and be an admin, to be able to read songs.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No arguments are expected.");
                        }

                        break;
                    case "UpdateSong":
                        if (1 < arguments.Count && arguments.Count <= 4)
                        {
                            if (this.IsAdmin())
                            {
                                this.songsController.Update(arguments);
                            }
                            else
                            {
                                Console.WriteLine("You need to login and be an admin, to be able to update songs.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Between 2 and 4 arguments are expected - the id is mandatory, the next arguments are the fields you wish to update - title, year or artists.");
                        }

                        break;
                    case "DeleteSong":
                        if (arguments.Count == 1)
                        {
                            if (this.IsAdmin())
                            {
                                this.songsController.Delete(arguments);
                            }
                            else
                            {
                                Console.WriteLine("You need to login and be an admin, to be able to delete songs.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Exactly 1 argument is expected - the id of song.");
                        }

                        break;
                    case "CreatePlaylist":
                        if (arguments.Count == 2)
                        {
                            if (this.IsLoggedIn())
                            {
                                this.playlistsController.Create(arguments, this.usersController.CurrentUser.Id);
                            }
                            else
                            {
                                Console.WriteLine("You need to login to be able to create playlists.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Exactly 2 arguments are expected - name and description.");
                        }

                        break;
                    case "ReadPlaylists":
                        if (arguments.Count == 0)
                        {
                            if (this.IsLoggedIn())
                            {
                                this.playlistsController.Read();
                            }
                            else
                            {
                                Console.WriteLine("You need to login to be able to read playlists.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No arguments are expected.");
                        }

                        break;
                    case "UpdatePlaylist":
                        if (1 < arguments.Count && arguments.Count <= 3)
                        {
                            if (this.IsLoggedIn())
                            {
                                this.playlistsController.Update(arguments, this.usersController.CurrentUser.Id);
                            }
                            else
                            {
                                Console.WriteLine("You need to login to be able to update your playlists.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Between 2 and 3 arguments are expected - the id is mandatory, the next arguments are the fields you wish to update - name or description.");
                        }

                        break;
                    case "DeletePlaylist":
                        if (arguments.Count == 1)
                        {
                            if (this.IsLoggedIn())
                            {
                                this.playlistsController.Delete(arguments, this.usersController.CurrentUser.Id);
                            }
                            else
                            {
                                Console.WriteLine("You need to login to be able to delete your playlists.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Exactly 1 argument is expected - the id of playlist.");
                        }

                        break;
                    case "SharePlaylist":
                        if (arguments.Count == 1)
                        {
                            if (this.IsLoggedIn())
                            {
                                this.playlistsController.Share(arguments, this.usersController.CurrentUser.Id);
                            }
                            else
                            {
                                Console.WriteLine("You need to login to be able to share your playlists.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Exactly 1 argument is expected - the id of playlist.");
                        }

                        break;
                    case "AddSongToPlaylist":
                        if (arguments.Count == 2)
                        {
                            if (this.IsLoggedIn())
                            {
                                this.playlistsController.AddSong(arguments, this.usersController.CurrentUser.Id);
                            }
                            else
                            {
                                Console.WriteLine("You need to login to be able to add songs to your playlists.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Exactly 2 arguments are expected - songId and playlistId.");
                        }

                        break;
                    case "RemoveSongFromPlaylist":
                        if (arguments.Count == 2)
                        {
                            if (this.IsLoggedIn())
                            {
                                this.playlistsController.RemoveSong(arguments, this.usersController.CurrentUser.Id);
                            }
                            else
                            {
                                Console.WriteLine("You need to login to be able to remove songs from your playlists.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Exactly 2 arguments are expected - songId and playlistId.");
                        }

                        break;
                    case "Register":
                        if (2 < arguments.Count && arguments.Count <= 4)
                        {
                            if (this.IsLoggedIn())
                            {
                                Console.WriteLine("There is already someone logged in.");
                            }
                            else
                            {
                                this.usersController.Register(arguments);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Between 2 and 4 arguments are expected - email, password and display name are mandatory, 4th argument is wether or not you wish to be admin.");
                        }

                        break;
                    case "Login":
                        if (arguments.Count == 2)
                        {
                            if (this.IsLoggedIn())
                            {
                                Console.WriteLine("There is already someone logged in.");
                            }
                            else
                            {
                                this.usersController.Login(arguments);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Exactly 2 arguments are expected - email and password.");
                        }

                        break;
                    case "Logout":
                        if (arguments.Count == 0)
                        {
                            if (this.IsLoggedIn())
                            {
                                this.usersController.Logout();
                            }
                            else
                            {
                                Console.WriteLine("There is noone logged in.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No arguments are expected.");
                        }

                        break;
                    case "CurrentUser":
                        if (arguments.Count == 0)
                        {
                            if (this.IsLoggedIn())
                            {
                                Console.WriteLine(this.usersController.CurrentUser.Email);
                            }
                            else
                            {
                                Console.WriteLine("There is noone logged in.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No arguments are expected.");
                        }

                        break;
                    default:
                        Console.WriteLine($"Command {command} is not supported.");

                        break;
                }

                input = Console.ReadLine();
            }
        }

        private bool IsLoggedIn()
        {
            if (this.usersController.CurrentUser != null)
            {
                return true;
            }

            return false;
        }

        private bool IsAdmin()
        {
            if (this.IsLoggedIn() && this.usersController.CurrentUser.IsAdministrator)
            {
                return true;
            }

            return false;
        }
    }
}
