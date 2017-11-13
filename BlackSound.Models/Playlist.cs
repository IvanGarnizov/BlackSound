namespace BlackSound.Models
{
    using System.Collections.Generic;

    public class Playlist
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Song> Songs { get; set; }

        public bool IsPublic { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
