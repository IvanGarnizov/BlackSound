namespace BlackSound.Data.Repositories
{
    using Models;

    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(string filePath)
            : base(filePath)
        {
        }

        protected override void UpdateModel(User modelToUpdate, User model)
        {
        }
    }
}
