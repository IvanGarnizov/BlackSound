namespace BlackSound.Client.Core.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Models;

    class SongsController : BlackSoundController
    {
        public void Create(List<string> arguments)
        {
            var songs = this.Context.GetSongs();
            int lastId = 0;

            if (songs.Count > 0)
            {
                lastId = songs.Last().Id;
            }

            string title = arguments[0];
            int year = int.Parse(arguments[1]);
            List<string> artistsNames = arguments[2].Split(' ').ToList();

            var song = new Song()
            {
                Id = ++lastId,
                Title = title,
                Year = year,
                ArtistsNames = artistsNames
            };

            songs.Add(song);

            this.SaveChanges(songs);

            Console.WriteLine($"Song {title} successfully created.");
        }

        public void Read()
        {
            var songs = this.Context.GetSongs();

            if (songs.Count > 0)
            {
                foreach (var song in songs)
                {
                    Console.WriteLine(song.ToString());
                }
            }
            else
            {
                Console.WriteLine("There are no songs registered.");
            }
        }

        public void Update(List<string> arguments)
        {
            int id = int.Parse(arguments[0]);
            var songs = this.Context.GetSongs();
            var song = songs
                .FirstOrDefault(s => s.Id == id);

            if (song != null)
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
                                year = int.Parse(value);

                                break;
                            case "Artists":
                                artistsNames = value.Split(' ').ToList();

                                break;
                            default:
                                Console.WriteLine($"Field {field} is not present in a song.");

                                hasIncorrectField = true;

                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("An argument is not in correct format. The correct format is {field}=value, where {field} stands for [Title, Year or Artists]");

                        hasIncorrectField = true;

                        break;
                    }
                }

                if (!hasIncorrectField)
                {
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

                    this.SaveChanges(songs);

                    Console.WriteLine($"Song {song.Title} successfully updated.");
                }
            }
            else
            {
                Console.WriteLine($"Song with id {id} doesn't exist.");
            }
        }

        public void Delete(List<string> arguments)
        {
            int id = int.Parse(arguments[0]);
            var songs = this.Context.GetSongs();
            var song = songs
                .FirstOrDefault(s => s.Id == id);

            if (song != null)
            {
                songs.Remove(song);

                this.SaveChanges(songs);

                Console.WriteLine($"Song {song.Title} successfully deleted.");
            }
            else
            {
                Console.WriteLine($"Song with id {id} doesn't exist.");
            }
        }
    }
}
