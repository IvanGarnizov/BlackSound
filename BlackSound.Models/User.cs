namespace BlackSound.Models
{
    using System.Collections.Generic;

    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string DisplayName { get; set; }

        public bool IsAdministrator { get; set; }

        public ICollection<Playlist> Playlists { get; set; }
    }
}
