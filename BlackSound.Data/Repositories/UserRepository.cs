namespace BlackSound.Data.Repositories
{
    using Models;

    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(string filePath)
            : base(filePath)
        {
        }
    }
}
