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
            int lastId = 0;

            if (users.Count > 0)
            {
                lastId = users.Last().Id;
            }

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
                bool isAdmin = false;

                if (arguments.Count > 3)
                {
                    isAdmin = true;

                    var playlists = this.Context.GetPlaylists();

                    playlists.Add(new Playlist()
                    {
                        Id = 1,
                        Name = "All Songs",
                        Description = "All songs on Black Sound",
                        IsPublic = true,
                        UserId = lastId + 1
                    });

                    this.SaveChanges(null, playlists);
                }

                user = new User()
                {
                    Id = ++lastId,
                    Email = email,
                    Password = password,
                    DisplayName = displayName,
                    IsAdministrator = isAdmin
                };

                users.Add(user);

                this.SaveChanges(null, null, users);

                Console.WriteLine(Messages.UserRegistered(user.Email));

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
