namespace BlackSound.Data.Repositories
{
    using System.Linq;

    using Models;

    public class PlaylistRepository : BaseRepository<Playlist>
    {
        public PlaylistRepository(string filePath)
            : base(filePath)
        {
        }

        public Playlist GetByNameAndStatus(string name)
        {
            return GetAll()
                .FirstOrDefault(p => p.Name == name && p.IsPublic);
        }

        public Playlist GetMasterPlaylist()
        {
            return GetAll()
                .First(p => p.Name == "All Songs");
        }
    }
}
