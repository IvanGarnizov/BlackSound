namespace BlackSound.Models
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class Song
    {
        private static int id;

        public Song()
        {
            this.Id = Interlocked.Increment(ref id);
            this.ArtistsNames = new List<string>();
            this.Playlists = new List<Playlist>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public ICollection<string> ArtistsNames { get; set; }

        public ICollection<Playlist> Playlists { get; set; }

        public override string ToString()
        {
            return $"Id: {this.Id}, Title: {this.Title}, Year: {this.Year}, Artists: {String.Join(" - ", this.ArtistsNames)}";
        }
    }
}
