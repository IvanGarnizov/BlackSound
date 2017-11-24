namespace BlackSound.Client.Core.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Models;

    using Utility;

    class UsersController : BaseController
    {
        public User CurrentUser { get; set; }

        public void Register(List<string> arguments)
        {
            int id = userRepository.GetId();
            string email = arguments[0];
            var user = userRepository.GetAll()
                .FirstOrDefault(u => u.Email == email);

            if (!Validator.UserExists(user))
            {
                string password = arguments[1];
                string displayName = arguments[2];

                user = new User()
                {
                    Id = id,
                    Email = email,
                    Password = password,
                    DisplayName = displayName,
                    IsAdministrator = false
                };
                userRepository.Insert(user);

                Console.WriteLine(Messages.UserRegistered(email));

                this.Login(new List<string>(new string[] { email, password }));
            }
        }

        public void Login(List<string> arguments)
        {
            string email = arguments[0];
            string password = arguments[1];
            var user = userRepository.GetAll()
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
    }
}
