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

        protected override void UpdateModel(Playlist modelToUpdate, Playlist model)
        {
            modelToUpdate.Name = model.Name;
            modelToUpdate.Description = model.Description;
            modelToUpdate.IsPublic = model.IsPublic;
            modelToUpdate.SongIds = model.SongIds;
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
