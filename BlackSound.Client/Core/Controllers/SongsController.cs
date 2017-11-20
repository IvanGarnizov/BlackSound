﻿namespace BlackSound.Client.Core.Controllers
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Utility;

    class SongsController : BlackSoundController
    {
        public void Create(List<string> arguments)
        {
            if (Validator.IsInteger(arguments[1], out int year, "Year"))
            {
                var songs = this.Context.GetSongs();
                int lastId = 0;

                if (songs.Count > 0)
                {
                    lastId = songs.Last().Id;
                }

                string title = arguments[0];
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
            if (Validator.IsInteger(arguments[0], out int id, "Id"))
            {
                var songs = this.Context.GetSongs();
                
                if (Validator.SongExists(id, songs, out Song song))
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
            }
        }

        public void Delete(List<string> arguments)
        {
            if (Validator.IsInteger(arguments[0], out int id, "Id"))
            {
                var songs = this.Context.GetSongs();

                if (Validator.SongExists(id, songs, out Song song))
                {
                    songs.Remove(song);

                    this.SaveChanges(songs);

                    Console.WriteLine($"Song {song.Title} successfully deleted.");
                }
            }
        }
    }
}
