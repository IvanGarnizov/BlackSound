namespace BlackSound.Models
{
    public class User : BaseModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string DisplayName { get; set; }

        public bool IsAdministrator { get; set; }
    }
}
