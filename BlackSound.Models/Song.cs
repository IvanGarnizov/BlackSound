namespace BlackSound.Models
{
    using System.Collections.Generic;
    
    public class Song
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<string> ArtistsNames { get; set; }

        public int Year { get; set; }

        public int PlaylistId { get; set; }

        public Playlist Playlist { get; set; }

        public override string ToString()
        {
            return $"Title: {this.Title}, Year: {this.Year}";
        }
    }
}
