﻿namespace BlackSound.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string DisplayName { get; set; }

        public bool IsAdministrator { get; set; }
    }
}
