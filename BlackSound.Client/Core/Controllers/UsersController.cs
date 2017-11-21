namespace BlackSound.Client.Core.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Models;

    using Utility;

    class UsersController : BlackSoundController
    {
        public User CurrentUser { get; set; }

        public void Register(List<string> arguments)
        {
            var users = this.Context.GetUsers();
            int id = users.Count + 1;
            string email = arguments[0];
            var user = users
                .FirstOrDefault(u => u.Email == email);

            if (user != null)
            {
                Console.WriteLine(Messages.EmailExists);
            }
            else
            {
                string password = arguments[1];
                string displayName = arguments[2];

                users.Add(new User()
                {
                    Id = id,
                    Email = email,
                    Password = password,
                    DisplayName = displayName,
                    IsAdministrator = false
                });
                
                this.SaveChanges(null, null, users);

                Console.WriteLine(Messages.UserRegistered(email));

                this.Login(new List<string>(new string[] { email, password }));
            }
        }

        public void Login(List<string> arguments)
        {
            var users = this.Context.GetUsers();
            string email = arguments[0];
            string password = arguments[1];
            var user = users
                .FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                this.CurrentUser = user;

                Console.WriteLine(Messages.UserLoggedIn(user.Email));
            }
            else
            {
                Console.WriteLine(Messages.IncorrectEmailOrPassword);
            }
        }

        public void Logout()
        {
            string currentUserEmail = this.CurrentUser.Email;

            this.CurrentUser = null;

            Console.WriteLine(Messages.UserLogout(currentUserEmail));
        }

        public bool HasAdmin()
        {
            return this.Context.GetUsers()
                .Any(u => u.IsAdministrator);
        }
    }
}
