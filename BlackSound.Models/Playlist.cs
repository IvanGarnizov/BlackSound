namespace BlackSound.Models
{
    using System.Collections.Generic;
    using System.Threading;

    public class Playlist
    {
        private static int id;

        public Playlist()
        {
            this.Id = Interlocked.Increment(ref id);
            this.Songs = new List<Song>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsPublic { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<Song> Songs { get; set; }

        public override string ToString()
        {
            return $"Id: {this.Id}, Name: {this.Name}, Description: {this.Description}, Open: {(this.IsPublic ? "Yes" : "No")}";
        }
    }
}
