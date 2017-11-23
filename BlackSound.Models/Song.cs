namespace BlackSound.Models
{
    using System;
    using System.Collections.Generic;

    public class Song : BaseModel
    {
        public Song()
        {
            this.ArtistsNames = new List<string>();
        }
        
        public string Title { get; set; }

        public int Year { get; set; }

        public ICollection<string> ArtistsNames { get; set; }

        public override string ToString()
        {
            return $"~~~~~~~~~~~~~~\nId: {this.Id}\nTitle: {this.Title}\nYear: {this.Year}\nArtists: {String.Join(", ", this.ArtistsNames)}\n~~~~~~~~~~~~~~";
        }
    }
}
