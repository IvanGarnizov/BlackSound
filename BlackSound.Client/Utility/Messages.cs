namespace BlackSound.Client.Utility
{
    public static class Messages
    {
        public const string AddSongWrongNumberOfArguments = "Exactly 3 arguments are expected - title, year and artists.";
        public const string NoArgumentsExpected = "No arguments are expected.";
        public const string UpdateSongWrongNumberOfArguments = "Between 2 and 4 arguments are expected - the id is mandatory, the next arguments are the fields you wish to update - title, year or artists.";
        public const string DeleteSongWrongNumberOfArguments = "Exactly 1 argument is expected - the id of song.";
        public const string AddPlaylistWrongNumberOfArguments = "Exactly 2 arguments are expected - name and description.";
        public const string ReadPlaylistWrongNumberOfArguments = "Exactly 1 argument is expected - the name of playlist.";
        public const string UpdatePlaylistWrongNumberOfArguments = "Between 2 and 3 arguments are expected - the id is mandatory, the next arguments are the fields you wish to update - name or description.";
        public const string DeletePlaylistWrongNumberOfArguments = "Exactly 1 argument is expected - the id of playlist.";
        public const string SharePlaylistWrongNumberOfArguments = "Exactly 1 argument is expected - the id of playlist.";
        public const string AddSongToPlaylistWrongNumberOfArguments = "Exactly 2 arguments are expected - songId and playlistId.";
        public const string RemoveSongFromPlaylistWrongNumberOfArguments = "Exactly 2 arguments are expected - songId and playlistId.";
        public const string RegisterWrongNumberOfArguments = "Between 3 and 4 arguments are expected - email, password and display name are mandatory, 4th argument is wether or not you wish to be admin.";
        public const string LoginWrongNumberOfArguments = "Exactly 2 arguments are expected - email and password.";
        public const string AddSongNoAdmin = "You need to login and be an admin to be able to create songs.";
        public const string ReadSongsNoAdmin = "You need to login and be an admin to be able to read songs.";
        public const string UpdateSongNoAdmin = "You need to login and be an admin to be able to update songs.";
        public const string DeleteSongNoAdmin = "You need to login and be an admin to be able to delete songs.";
        public const string AddPlaylistNoLogin = "You need to login to be able to create playlists.";
        public const string ReadPlaylistsNoLogin = "You need to login to be able to read playlists.";
        public const string UpdatePlaylistNoLogin = "You need to login to be able to update your playlists.";
        public const string DeletePlaylistNoLogin = "You need to login to be able to delete your playlists.";
        public const string SharePlaylistNoLogin = "You need to login to be able to share your playlists.";
        public const string AddSongToPlaylistNoLogin = "You need to login to be able to add songs your playlists.";
        public const string RemoveSongFromPlaylistNoLogin = "You need to login to be able to remove songs from your playlists.";
        public const string SomeoneAlreadyLoggedIn = "There is already someone logged in.";
        public const string NooneLoggedIn = "There is noone logged in.";
    }
}
