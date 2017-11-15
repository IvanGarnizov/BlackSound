namespace BlackSound.Models
{
    using System.Collections.Generic;
    using System.Threading;

    public class User
    {
        private static int id;

        public User()
        {
            this.Id = Interlocked.Increment(ref id);
            this.Playlists = new List<Playlist>();
        }

        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string DisplayName { get; set; }

        public bool IsAdministrator { get; set; }

        public ICollection<Playlist> Playlists { get; set; }

        public override string ToString()
        {
            return $"Id: {this.Id}, Email: {this.Email}, Display Name: {this.DisplayName}, Is Admin: {(this.IsAdministrator ? "Yes" : "No")}";
        }
    }
}
