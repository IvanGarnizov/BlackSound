﻿namespace BlackSound.Models
{
    using System.Collections.Generic;

    public class Playlist : BaseModel
    {
        public Playlist()
        {
            this.SongIds = new List<int>();
        }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsPublic { get; set; }

        public int UserId { get; set; }

        public ICollection<int> SongIds { get; set; }

        public override string ToString()
        {
            return $"~~~~~~~~~~~~~~\nId: {this.Id}\nName: {this.Name}\nDescription: {this.Description}\nPublic: {(this.IsPublic ? "Yes" : "No")}";
        }
    }
}
