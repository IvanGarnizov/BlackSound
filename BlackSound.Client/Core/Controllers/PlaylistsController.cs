namespace BlackSound.Client.Core.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Models;

    class PlaylistsController : BlackSoundController
    {
        public void Create(List<string> arguments, int userId)
        {
            var playlists = this.Context.GetPlaylists();
            var users = this.Context.GetUsers();
            var user = users
                .First(u => u.Id == userId);
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
                Description = description,
                UserId = userId
            };

            playlists.Add(playlist);

            this.SaveChanges(null, playlists);

            Console.WriteLine($"Playlist {name} successfully created.");
        }

        public void Read()
        {
            var playlists = this.Context.GetPlaylists()
                .Where(p => p.IsPublic)
                .ToList();

            if (playlists.Count > 0)
            {
                foreach (var playlist in playlists)
                {
                    var songs = this.Context.GetSongsForPlaylist(playlist.Id);

                    Console.WriteLine(playlist.ToString() + "\nSongs: [" + String.Join(", ", songs.Select(s => $"{'"' + s.Title + '"'}")) + "]\n~~~~~~~~~~~~~~");
                }
            }
            else
            {
                Console.WriteLine("There are no playlists registered, or no public playlists.");
            }
        }

        public void Update(List<string> arguments, int userId)
        {
            int id = int.Parse(arguments[0]);
            var playlists = this.Context.GetPlaylists();
            var playlist = playlists
                .FirstOrDefault(p => p.Id == id && p.UserId == userId);

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
                Console.WriteLine($"Playlist with id {id} doesn't exist, or you're not the owner.");
            }
        }

        public void Delete(List<string> arguments, int userId)
        {
            int id = int.Parse(arguments[0]);
            var playlists = this.Context.GetPlaylists();
            var playlist = playlists
                .FirstOrDefault(p => p.Id == id && p.UserId == userId);

            if (playlist != null)
            {
                playlists.Remove(playlist);

                this.SaveChanges(null, playlists);

                Console.WriteLine($"Playlist {playlist.Name} successfully deleted.");
            }
            else
            {
                Console.WriteLine($"Playlist with id {id} doesn't exist, or you're not the owner.");
            }
        }

        public void Share(List<string> arguments, int userId)
        {
            int id = int.Parse(arguments[0]);
            var playlists = this.Context.GetPlaylists();
            var playlist = playlists
                .FirstOrDefault(p => p.Id == id && p.UserId == userId);

            if (playlist != null)
            {
                playlist.IsPublic = true;

                this.SaveChanges(null, playlists);

                Console.WriteLine($"Playlist {playlist.Name} successfully shared.");
            }
            else
            {
                Console.WriteLine($"Playlist with id {id} doesn't exist, or you're not the owner.");
            }
        }

        public void AddSong(List<string> arguments, int userId)
        {
            int songId = int.Parse(arguments[0]);
            var songs = this.Context.GetSongs();
            var song = songs
                .FirstOrDefault(s => s.Id == songId);

            if (song != null)
            {
                int playlistId = int.Parse(arguments[1]);
                var playlists = this.Context.GetPlaylists();
                var playlist = playlists
                    .FirstOrDefault(p => p.Id == playlistId && p.UserId == userId);

                if (playlist != null)
                {
                    playlist.SongIds.Add(songId);

                    this.SaveChanges(null, playlists);

                    Console.WriteLine($"Song {song.Title} successfully added to playlist {playlist.Name}.");
                }
                else
                {
                    Console.WriteLine($"Playlist with id {playlistId} doesn't exist, or you're not the owner.");
                }
            }
            else
            {
                Console.WriteLine($"Song with id {songId} doesn't exist.");
            }
        }

        public void RemoveSong(List<string> arguments, int userId)
        {
            int songId = int.Parse(arguments[0]);
            var songs = this.Context.GetSongs();
            var song = songs
                .FirstOrDefault(s => s.Id == songId);

            if (song != null)
            {
                int playlistId = int.Parse(arguments[1]);
                var playlists = this.Context.GetPlaylists();
                var playlist = playlists
                    .FirstOrDefault(p => p.Id == playlistId && p.UserId == userId);

                if (playlist != null)
                {
                    playlist.SongIds.Remove(songId);

                    this.SaveChanges(null, playlists);

                    Console.WriteLine($"Song {song.Title} successfully removed from playlist {playlist.Name}.");
                }
                else
                {
                    Console.WriteLine($"Playlist with id {playlistId} doesn't exist, or you're not the owner.");
                }
            }
            else
            {
                Console.WriteLine($"Song with id {songId} doesn't exist.");
            }
        }
    }
}
