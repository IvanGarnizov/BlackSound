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
        public const string RegisterWrongNumberOfArguments = "Exactly 3 arguments are expected - email, password and display name.";
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
        public const string NoSongsRegistered = "There are no songs registered.";
        public const string ArgumentIncorrectFormatForSong = "An argument is not in correct format. The correct format is {field}=value, where {field} stands for [Title, Year or Artists].";
        public const string EmailExists = "A user with this email already exists.";
        public const string IncorrectEmailOrPassword = "Email or password are incorrect.";
        public const string PlaylistNotExistingOrNotPublic = "There are no playlist with this name registered or it's not public.";
        public const string ArgumentIncorrectFormatForPlaylist = "An argument is not in correct format. The correct format is {field}=value, where {field} stands for [Name or Description]";

        public static string CommandNotSupported(string command)
        {
            return $"Command {command} is not supported.";
        }

        public static string SongCreated(string title)
        {
            return $"Song {title} successfully created.";
        }

        public static string FieldNotPresentSong(string field)
        {
            return $"Field {field} is not present in a song.";
        }

        public static string SongUpdated(string title)
        {
            return $"Song {title} successfully updated.";
        }

        public static string SongDeleted(string title)
        {
            return $"Song {title} successfully deleted.";
        }

        public static string UserRegistered(string email)
        {
            return $"User {email} successfully registered.";
        }

        public static string UserLoggedIn(string email)
        {
            return $"User {email} successfully logged in.";
        }

        public static string UserLogout(string email)
        {
            return $"User {email} successfully logged out.";
        }

        public static string PlaylistCreated(string name)
        {
            return $"Playlist {name} successfully created.";
        }

        public static string FieldNotPresentInPlaylist(string field)
        {
            return $"Field {field} is not present in a playlist.";
        }

        public static string PlaylistUpdated(string name)
        {
            return $"Playlist {name} successfully updated.";
        }

        public static string PlaylistDeleted(string name)
        {
            return $"Playlist {name} successfully deleted.";
        }

        public static string PlaylistShared(string name)
        {
            return $"Playlist {name} successfully shared.";
        }

        public static string AddedSongToPlaylist(string songTitle, string playlistName)
        {
            return $"Song {songTitle} successfully added to playlist {playlistName}.";
        }

        public static string RemovedSongFromPlaylist(string songTitle, string playlistName)
        {
            return $"Song {songTitle} successfully removed from playlist {playlistName}.";
        }

        public static string SongNoExist(int id)
        {
            return $"Song with id {id} doesn't exist.";
        }

        public static string PlaylistNoExistOrNoOwner(int id)
        {
            return $"Playlist with id {id} doesn't exist or you're not the owner.";
        }

        public static string NoInteger(string name)
        {
            return $"{name} is not an integer.";
        }
    }
}
