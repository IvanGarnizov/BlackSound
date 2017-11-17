namespace BlackSound.Models
{
    using System.Collections.Generic;
    using System.Threading;

    public class Playlist
    {
        public Playlist()
        {
            this.SongIds = new List<int>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsPublic { get; set; }

        public ICollection<int> SongIds { get; set; }

        public override string ToString()
        {
            return $"Id: {this.Id}, Name: {this.Name}, Description: {this.Description}, Public: {(this.IsPublic ? "Yes" : "No")}";
        }
    }
}
