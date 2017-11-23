namespace BlackSound.Client.Core.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Models;

    using Utility;

    class SongsController : BaseController
    {
        public void Create(List<string> arguments)
        {
            if (Validator.IsInteger(arguments[1], out int year, "Year"))
            {
                int id = songRepository.GetId();
                string title = arguments[0];
                List<string> artistsNames = arguments[2].Split(' ').ToList();
                var song = new Song()
                {
                    Id = id,
                    Title = title,
                    Year = year,
                    ArtistsNames = artistsNames
                };

                songRepository.Insert(song);

                Console.WriteLine(Messages.SongCreated(title));
            }
        }

        public void Read()
        {
            var songs = songRepository.GetAll();

            if (songs.Count > 0)
            {
                foreach (var song in songs)
                {
                    Console.WriteLine(song.ToString());
                }
            }
            else
            {
                Console.WriteLine(Messages.NoSongsRegistered);
            }
        }

        public void Update(List<string> arguments)
        {
            if (Validator.IsInteger(arguments[0], out int id, "Id"))
            {
                var songs = songRepository.GetAll();
                
                if (Validator.SongExists(id, songs, out Song songToUpdate))
                {
                    arguments.RemoveAt(0);

                    string title = String.Empty;
                    int year = 0;
                    var artistsNames = new List<string>();
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
                                case "Title":
                                    title = value;

                                    break;
                                case "Year":
                                    if (!Validator.IsInteger(value, out year, "Year"))
                                    {
                                        hasIncorrectField = true;
                                    }

                                    break;
                                case "Artists":
                                    artistsNames = value.Split(' ').ToList();

                                    break;
                                default:
                                    Console.WriteLine(Messages.FieldNotPresentSong(field));

                                    hasIncorrectField = true;

                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine(Messages.ArgumentIncorrectFormatForSong);

                            hasIncorrectField = true;

                            break;
                        }
                    }

                    if (!hasIncorrectField)
                    {
                        var song = songToUpdate;

                        if (!String.IsNullOrEmpty(title))
                        {
                            song.Title = title;
                        }

                        if (year != 0)
                        {
                            song.Year = year;
                        }

                        if (artistsNames.Count > 0)
                        {
                            song.ArtistsNames = artistsNames;
                        }

                        songRepository.Update(song);

                        Console.WriteLine(Messages.SongUpdated(song.Title));
                    }
                }
            }
        }

        public void Delete(List<string> arguments)
        {
            if (Validator.IsInteger(arguments[0], out int id, "Id"))
            {
                var songs = songRepository.GetAll();

                if (Validator.SongExists(id, songs, out Song song))
                {
                    var playlists = playlistRepository.GetAll();

                    foreach (var playlist in playlists)
                    {
                        if (playlist.SongIds.Contains(id))
                        {
                            playlist.SongIds.Remove(id);
                        }
                    }

                    songRepository.Delete(song);

                    Console.WriteLine(Messages.SongDeleted(song.Title));
                }
            }
        }
    }
}
