namespace BlackSound.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Models;

    public class SongRepository : BaseRepository<Song>
    {
        public SongRepository(string filePath)
            : base(filePath)
        {
        }

        public List<Song> GetForPlaylist(Playlist playlist)
        {
            var songs = new List<Song>();

            foreach (var songId in playlist.SongIds)
            {
                var song = GetAll()
                    .First(s => s.Id == songId);

                songs.Add(song);
            }

            return songs;
        }
    }
}
