namespace BlackSound.Client.Core.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Models;

    using Utility;

    class PlaylistsController : BaseController
    {
        public void Create(List<string> arguments, int userId)
        {
            var playlists = playlistRepository.GetAll();
            string name = arguments[0];

            if (!Validator.PlaylistExistsName(name, playlists))
            {
                var user = userRepository.GetById(userId);
                int id = playlistRepository.GetId();
                string description = arguments[1];
                var playlist = new Playlist()
                {
                    Id = id,
                    Name = name,
                    Description = description,
                    UserId = userId
                };

                playlistRepository.Insert(playlist);

                Console.WriteLine(Messages.PlaylistCreated(name));
            }
        }

        public void Read(List<string> arguments)
        {
            string name = arguments[0];
            var playlist = playlistRepository.GetByNameAndStatus(name);

            if (playlist != null)
            {
                var songs = songRepository.GetForPlaylist(playlist);

                Console.WriteLine(playlist.ToString() + "\nSongs: [" + String.Join(", ", songs.Select(s => $"{'"' + s.Title + '"'}")) + "]\n~~~~~~~~~~~~~~");
            }
            else
            {
                Console.WriteLine(Messages.PlaylistNotExistingOrNotPublic);
            }
        }

        public void Update(List<string> arguments, int userId)
        {
            if (Validator.IsInteger(arguments[0], out int id, "Id"))
            {
                var playlists = playlistRepository.GetAll();

                if (Validator.PlaylistExistsId(id, userId, playlists, out Playlist playlist))
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
                                    Console.WriteLine(Messages.FieldNotPresentInPlaylist(field));

                                    hasIncorrectField = true;

                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine(Messages.ArgumentIncorrectFormatForPlaylist);

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

                        playlistRepository.Update(playlist);

                        Console.WriteLine(Messages.PlaylistUpdated(playlist.Name));
                    }
                }
            }
        }

        public void Delete(List<string> arguments, int userId)
        {
            if (Validator.IsInteger(arguments[0], out int id, "Id"))
            {
                var playlists = playlistRepository.GetAll();

                if (Validator.PlaylistExistsId(id, userId, playlists, out Playlist playlist))
                {
                    playlistRepository.Delete(id);

                    Console.WriteLine(Messages.PlaylistDeleted(playlist.Name));
                }
            }
        }

        public void Share(List<string> arguments, int userId)
        {
            if (Validator.IsInteger(arguments[0], out int id, "Id"))
            {
                var playlists = playlistRepository.GetAll();

                if (Validator.PlaylistExistsId(id, userId, playlists, out Playlist playlist))
                {
                    playlist.IsPublic = true;

                    playlistRepository.Update(playlist);

                    Console.WriteLine(Messages.PlaylistShared(playlist.Name));
                }
            }
        }

        public void AddSong(List<string> arguments, int userId)
        {
            if (Validator.IsInteger(arguments[0], out int songId, "SongId"))
            {
                var songs = songRepository.GetAll();

                if (Validator.SongExists(songId, songs, out Song song))
                {
                    if (Validator.IsInteger(arguments[1], out int playlistId, "PlaylistId"))
                    {
                        var playlists = playlistRepository.GetAll();

                        if (Validator.PlaylistExistsId(playlistId, userId, playlists, out Playlist playlist))
                        {
                            playlist.SongIds.Add(songId);
                            playlistRepository.Update(playlist);

                            Console.WriteLine(Messages.AddedSongToPlaylist(song.Title, playlist.Name));
                        }
                    }
                }
            }
        }

        public void RemoveSong(List<string> arguments, int userId)
        {
            if (Validator.IsInteger(arguments[0], out int songId, "SongId"))
            {
                if (Validator.IsInteger(arguments[1], out int playlistId, "PlaylistId"))
                {
                    var playlists = playlistRepository.GetAll();

                    if (Validator.PlaylistExistsId(playlistId, userId, playlists, out Playlist playlist))
                    {
                        var songs = songRepository.GetForPlaylist(playlist);

                        if (Validator.SongExists(songId, songs, out Song song))
                        {   
                            playlist.SongIds.Remove(songId);
                            playlistRepository.Update(playlist);

                            Console.WriteLine(Messages.RemovedSongFromPlaylist(song.Title, playlist.Name));
                        }
                    }
                }
            }
        }
    }
}
