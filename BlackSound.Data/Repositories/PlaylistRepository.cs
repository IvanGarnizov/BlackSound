namespace BlackSound.Data.Repositories
{
    using System.Collections.Generic;
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
        }

        public Playlist GetByNameAndStatus(string name)
        {
            return GetAll()
                .FirstOrDefault(p => p.Name == name && p.IsPublic);
        }

        public void AddSong(List<Playlist> playlists, int playlistId, int songId)
        {
            var playlist = playlists
                .First(p => p.Id == playlistId);

            playlist.SongIds.Add(songId);
            
        }

        public void RemoveFromPlaylists(Playlist playlist)
        {

        }
    }
}
