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
            var songs = this.Context.Songs;
            int lastId = 0;

            if (songs.Count > 0)
            {
                lastId = songs.Last().Id;
            }

            string title = arguments[0];
            int year = int.Parse(arguments[1]);
            var song = new Song()
            {
                Id = ++lastId,
                Title = title,
                Year = year
            };

            songs.Add(song);

            this.SaveChanges(songs);

            Console.WriteLine($"Song {title} successfully created.");
        }

        public void Read()
        {
            var songs = this.Context.Songs;

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
            var songs = this.Context.Songs;
            var song = songs
                .FirstOrDefault(s => s.Id == id);

            if (song != null)
            {
                arguments.RemoveAt(0);

                string title = String.Empty;
                int year = 0;

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


                                break;
                            default:
                                Console.WriteLine($"There is no such field {field} in a song.");

                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("An argument is not in correct format. The correct format is {field}=value, where {field} stands for [Title, Year or Artists]");
                    }
                }

                if (!String.IsNullOrEmpty(title))
                {
                    song.Title = title;
                }

                if (year != 0)
                {
                    song.Year = year;
                }

                this.SaveChanges(songs);

                Console.WriteLine($"Song {song.Title} successfully updated.");
            }
            else
            {
                Console.WriteLine($"Song with id {id} doesn't exist.");
            }
        }

        public void Delete(List<string> arguments)
        {
            int id = int.Parse(arguments[0]);
            var songs = this.Context.Songs;
            var song = songs
                .FirstOrDefault(s => s.Id == id);

            if (song != null)
            {
                songs.Remove(song);

                this.SaveChanges(songs);
            }
            else
            {
                Console.WriteLine($"Song with id {id} doesn't exist.");
            }
        }
    }
}
