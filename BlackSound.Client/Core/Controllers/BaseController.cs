namespace BlackSound.Client.Core.Controllers
{
    using System.Collections.Generic;

    using Data.Repositories;

    using Models;

    abstract class BaseController
    {
        private const string UsersPath = "../../../BlackSound.Data/users.json";
        private const string PlaylistsPath = "../../../BlackSound.Data/playlists.json";
        private const string SongsPath = "../../../BlackSound.Data/songs.json";

        protected UserRepository userRepository;
        protected PlaylistRepository playlistRepository;
        protected SongRepository songRepository;

        public BaseController()
        {
            userRepository = new UserRepository(UsersPath);
            playlistRepository = new PlaylistRepository(PlaylistsPath);
            songRepository = new SongRepository(SongsPath);
        }

        public void Seed()
        {
            if (userRepository.GetAll().Count == 0)
            {
                var admin = new User()
                {
                    Id = 1,
                    Email = "a",
                    Password = "b",
                    DisplayName = "c",
                    IsAdministrator = true
                };

                userRepository.Insert(admin);

                var allSongsPlaylist = new Playlist()
                {
                    Id = 1,
                    Name = "All Songs",
                    Description = "All songs on Black Sound",
                    UserId = 1
                };

                playlistRepository.Insert(allSongsPlaylist);

                var song = new Song()
                {
                    Id = 1,
                    Title = "a",
                    Year = 1,
                    ArtistsNames = new List<string>()
                };

                songRepository.Insert(song);
            }
        }
    }
}
