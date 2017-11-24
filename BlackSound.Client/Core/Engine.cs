namespace BlackSound.Client.Core
{
    using System;
    using System.Linq;

    using Core.Controllers;

    using Utility;

    public class Engine
    {
        private string input;
        private SongsController songsController;
        private PlaylistsController playlistsController;
        private UsersController usersController;

        public Engine()
        {
            songsController = new SongsController();
            playlistsController = new PlaylistsController();
            usersController = new UsersController();
        }

        public void Run()
        {
            songsController.Seed();

            input = Console.ReadLine();

            while (input != "stop")
            {
                var arguments = input.Split(',').ToList();
                string command = arguments[0];

                arguments.RemoveAt(0);

                switch (command)
                {
                    case "CreateSong":
                        if (IsAdmin())
                        {
                            if (arguments.Count == 3)
                            {
                                songsController.Create(arguments);
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
                        if (IsAdmin())
                        {
                            if (arguments.Count == 0)
                            {
                                songsController.Read();
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
                        if (IsAdmin())
                        {
                            if (1 < arguments.Count && arguments.Count <= 4)
                            {
                                songsController.Update(arguments);
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
                        if (IsAdmin())
                        {
                            if (arguments.Count == 1)
                            {
                                songsController.Delete(arguments);
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
                        if (IsLoggedIn())
                        {
                            if (arguments.Count == 2)
                            {
                                playlistsController.Create(arguments, usersController.CurrentUser.Id);
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
                        if (IsLoggedIn())
                        {
                            if (arguments.Count == 1)
                            {
                                playlistsController.Read(arguments);
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
                        if (IsLoggedIn())
                        {
                            if (1 < arguments.Count && arguments.Count <= 3)
                            {
                                playlistsController.Update(arguments, usersController.CurrentUser.Id);
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
                        if (IsLoggedIn())
                        {
                            if (arguments.Count == 1)
                            {
                                playlistsController.Delete(arguments, usersController.CurrentUser.Id);
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
                        if (IsLoggedIn())
                        {
                            if (arguments.Count == 1)
                            {
                                playlistsController.Share(arguments, usersController.CurrentUser.Id);
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
                        if (IsLoggedIn())
                        {
                            if (arguments.Count == 2)
                            {
                                playlistsController.AddSong(arguments, usersController.CurrentUser.Id);
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
                        if (IsLoggedIn())
                        {
                            if (arguments.Count == 2)
                            {
                                playlistsController.RemoveSong(arguments, usersController.CurrentUser.Id);
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
                        if (!IsLoggedIn())
                        {
                            if (arguments.Count == 3)
                            {
                                usersController.Register(arguments);
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
                        if (!IsLoggedIn())
                        {
                            if (arguments.Count == 2)
                            {
                                usersController.Login(arguments);
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
                        if (IsLoggedIn())
                        {
                            if (arguments.Count == 0)
                            {
                                usersController.Logout();
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
                        if (IsLoggedIn())
                        {
                            if (arguments.Count == 0)
                            {
                                Console.WriteLine(usersController.CurrentUser.Email);
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
            if (usersController.CurrentUser != null)
            {
                return true;
            }

            return false;
        }

        private bool IsAdmin()
        {
            if (IsLoggedIn() && usersController.CurrentUser.IsAdministrator)
            {
                return true;
            }

            return false;
        }
    }
}
