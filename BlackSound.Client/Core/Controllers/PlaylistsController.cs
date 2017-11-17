namespace BlackSound.Client.Core.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Models;

    class PlaylistsController : BlackSoundController
    {
        public void Create(List<string> arguments)
        {
            var playlists = this.Context.Playlists;
            int lastId = 0;

            if (playlists.Count > 0)
            {
                lastId = playlists.Last().Id;
            }

            string name = arguments[0];
            string description = arguments[1];
            var playlist = new Playlist()
            {
                Id = ++lastId,
                Name = name,
                Description = description
            };

            playlists.Add(playlist);

            this.SaveChanges(null, playlists);

            Console.WriteLine($"Playlist {name} successfully created.");
        }

        public void Read()
        {
            var playlists = this.Context.Playlists
                .Where(p => p.IsPublic)
                .ToList();

            if (playlists.Count > 0)
            {
                foreach (var playlist in playlists)
                {
                    Console.WriteLine(playlist.ToString());
                }
            }
            else
            {
                Console.WriteLine("There are no playlists registered, or no public playlists.");
            }
        }

        public void Update(List<string> arguments)
        {
            int id = int.Parse(arguments[0]);
            var playlists = this.Context.Playlists;
            var playlist = playlists
                .FirstOrDefault(p => p.Id == id);

            if (playlist != null)
            {
                arguments.RemoveAt(0);

                string name = String.Empty;
                string description = String.Empty;
                bool hasIncorrectField = false;

                foreach (var pair in arguments)
                {
                    if (pair.Contains("="))
                    {
                        string[] parts = pair.Split('=');
                        string field = parts[0];
                        string value = parts[1];

                        switch (field)
                        {
                            case "Name":
                                name = value;

                                break;
                            case "Description":
                                description = value;

                                break;
                            default:
                                Console.WriteLine($"Field {field} is not present in a playlist.");

                                hasIncorrectField = true;

                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("An argument is not in correct format. The correct format is {field}=value, where {field} stands for [Name or Description]");

                        hasIncorrectField = true;

                        break;
                    }
                }

                if (!hasIncorrectField)
                {
                    if (!String.IsNullOrEmpty(name))
                    {
                        playlist.Name = name;
                    }

                    if (!String.IsNullOrEmpty(description))
                    {
                        playlist.Description = description;
                    }

                    this.SaveChanges(null, playlists);

                    Console.WriteLine($"Playlist {playlist.Name} successfully updated.");
                }
            }
            else
            {
                Console.WriteLine($"Playlist with id {id} doesn't exist.");
            }
        }

        public void Delete(List<string> arguments)
        {
            int id = int.Parse(arguments[0]);
            var playlists = this.Context.Playlists;
            var playlist = playlists
                .FirstOrDefault(s => s.Id == id);

            if (playlist != null)
            {
                playlists.Remove(playlist);

                this.SaveChanges(null, playlists);

                Console.WriteLine($"Playlist {playlist.Name} successfully deleted.");
            }
            else
            {
                Console.WriteLine($"Playlist with id {id} doesn't exist.");
            }
        }

        public void Share(List<string> arguments)
        {
            int id = int.Parse(arguments[0]);
            var playlists = this.Context.Playlists;
            var playlist = playlists
                .FirstOrDefault(s => s.Id == id);

            if (playlist != null)
            {
                playlist.IsPublic = true;

                this.SaveChanges(null, playlists);

                Console.WriteLine($"Playlist {playlist.Name} successfully shared.");
            }
            else
            {
                Console.WriteLine($"Playlist with id {id} doesn't exist.");
            }
        }
    }
}
