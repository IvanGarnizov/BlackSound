namespace BlackSound.Client.Core
{
    using System;
    using System.Linq;

    using Core.Controllers;

    using Data;

    using Utility;

    public class Engine
    {
        private string input;
        private SongsController songsController;
        private PlaylistsController playlistsController;
        private UsersController usersController;
        private BlackSoundContext context;

        public Engine()
        {
            this.songsController = new SongsController();
            this.playlistsController = new PlaylistsController();
            this.usersController = new UsersController();
            this.context = new BlackSoundContext();
        }

        public void Run()
        {
            this.context.Seed();
            this.input = Console.ReadLine();

            while (input != "stop")
            {
                var arguments = input.Split(',').ToList();
                string command = arguments[0];

                arguments.RemoveAt(0);

                switch (command)
                {
                    case "CreateSong":
                        if (this.IsAdmin())
                        {
                            if (arguments.Count == 3)
                            {
                                this.songsController.Create(arguments);
                            }
                            else
                            {
                                Console.WriteLine(Messages.AddSongWrongNumberOfArguments);
                            }
                        }
                        else
                        {
                            Console.WriteLine(Messages.AddSongNoAdmin);
                        }

                        break;
                    case "ReadSongs":
                        if (this.IsAdmin())
                        {
                            if (arguments.Count == 0)
                            {
                                this.songsController.Read();
                            }
                            else
                            {
                                Console.WriteLine(Messages.NoArgumentsExpected);
                            }
                        }
                        else
                        {
                            Console.WriteLine(Messages.ReadSongsNoAdmin);
                        }

                        break;
                    case "UpdateSong":
                        if (this.IsAdmin())
                        {
                            if (1 < arguments.Count && arguments.Count <= 4)
                            {
                                this.songsController.Update(arguments);
                            }
                            else
                            {
                                Console.WriteLine(Messages.UpdateSongWrongNumberOfArguments);
                            }
                        }
                        else
                        {
                            Console.WriteLine(Messages.UpdateSongNoAdmin);
                        }

                        break;
                    case "DeleteSong":
                        if (this.IsAdmin())
                        {
                            if (arguments.Count == 1)
                            {
                                this.songsController.Delete(arguments);
                            }
                            else
                            {
                                Console.WriteLine(Messages.DeleteSongWrongNumberOfArguments);
                            }
                        }
                        else
                        {
                            Console.WriteLine(Messages.DeleteSongNoAdmin);
                        }

                        break;
                    case "CreatePlaylist":
                        if (this.IsLoggedIn())
                        {
                            if (arguments.Count == 2)
                            {
                                this.playlistsController.Create(arguments, this.usersController.CurrentUser.Id);
                            }
                            else
                            {
                                Console.WriteLine(Messages.AddPlaylistWrongNumberOfArguments);
                            }
                        }
                        else
                        {
                            Console.WriteLine(Messages.AddPlaylistNoLogin);
                        }

                        break;
                    case "ReadPlaylist":
                        if (this.IsLoggedIn())
                        {
                            if (arguments.Count == 1)
                            {
                                this.playlistsController.Read(arguments);
                            }
                            else
                            {
                                Console.WriteLine(Messages.ReadPlaylistWrongNumberOfArguments);
                            }
                        }
                        else
                        {
                            Console.WriteLine(Messages.ReadPlaylistsNoLogin);
                        }

                        break;
                    case "UpdatePlaylist":
                        if (this.IsLoggedIn())
                        {
                            if (1 < arguments.Count && arguments.Count <= 3)
                            {
                                this.playlistsController.Update(arguments, this.usersController.CurrentUser.Id);
                            }
                            else
                            {
                                Console.WriteLine(Messages.UpdatePlaylistWrongNumberOfArguments);
                            }
                        }
                        else
                        {
                            Console.WriteLine(Messages.UpdatePlaylistNoLogin);
                        }

                        break;
                    case "DeletePlaylist":
                        if (this.IsLoggedIn())
                        {
                            if (arguments.Count == 1)
                            {
                                this.playlistsController.Delete(arguments, this.usersController.CurrentUser.Id);
                            }
                            else
                            {
                                Console.WriteLine(Messages.DeletePlaylistWrongNumberOfArguments);
                            }
                        }
                        else
                        {
                            Console.WriteLine(Messages.DeletePlaylistNoLogin);
                        }

                        break;
                    case "SharePlaylist":
                        if (this.IsLoggedIn())
                        {
                            if (arguments.Count == 1)
                            {
                                this.playlistsController.Share(arguments, this.usersController.CurrentUser.Id);
                            }
                            else
                            {
                                Console.WriteLine(Messages.SharePlaylistWrongNumberOfArguments);
                            }
                        }
                        else
                        {
                            Console.WriteLine(Messages.SharePlaylistNoLogin);
                        }


                        break;
                    case "AddSongToPlaylist":
                        if (this.IsLoggedIn())
                        {
                            if (arguments.Count == 2)
                            {
                                this.playlistsController.AddSong(arguments, this.usersController.CurrentUser.Id);
                            }
                            else
                            {
                                Console.WriteLine(Messages.AddSongToPlaylistWrongNumberOfArguments);
                            }
                        }
                        else
                        {
                            Console.WriteLine(Messages.AddSongToPlaylistNoLogin);
                        }

                        break;
                    case "RemoveSongFromPlaylist":
                        if (this.IsLoggedIn())
                        {
                            if (arguments.Count == 2)
                            {
                                this.playlistsController.RemoveSong(arguments, this.usersController.CurrentUser.Id);
                            }
                            else
                            {
                                Console.WriteLine(Messages.RemoveSongFromPlaylistWrongNumberOfArguments);
                            }
                        }
                        else
                        {
                            Console.WriteLine(Messages.RemoveSongFromPlaylistNoLogin);
                        }

                        break;
                    case "Register":
                        if (!this.IsLoggedIn())
                        {
                            if (arguments.Count == 3)
                            {
                                this.usersController.Register(arguments);
                            }
                            else
                            {
                                Console.WriteLine(Messages.RegisterWrongNumberOfArguments);
                            }
                        }
                        else
                        {
                            Console.WriteLine(Messages.SomeoneAlreadyLoggedIn);
                        }

                        break;
                    case "Login":
                        if (!this.IsLoggedIn())
                        {
                            if (arguments.Count == 2)
                            {
                                this.usersController.Login(arguments);
                            }
                            else
                            {
                                Console.WriteLine(Messages.LoginWrongNumberOfArguments);
                            }
                        }
                        else
                        {
                            Console.WriteLine(Messages.SomeoneAlreadyLoggedIn);
                        }

                        break;
                    case "Logout":
                        if (this.IsLoggedIn())
                        {
                            if (arguments.Count == 0)
                            {
                                this.usersController.Logout();
                            }
                            else
                            {
                                Console.WriteLine(Messages.NoArgumentsExpected);
                            }
                        }
                        else
                        {
                            Console.WriteLine(Messages.NooneLoggedIn);
                        }

                        break;
                    case "CurrentUser":
                        if (this.IsLoggedIn())
                        {
                            if (arguments.Count == 0)
                            {
                                Console.WriteLine(this.usersController.CurrentUser.Email);
                            }
                            else
                            {
                                Console.WriteLine(Messages.NoArgumentsExpected);
                            }
                        }
                        else
                        {
                            Console.WriteLine(Messages.NooneLoggedIn);
                        }

                        break;
                    default:
                        Console.WriteLine(Messages.CommandNotSupported(command));

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
