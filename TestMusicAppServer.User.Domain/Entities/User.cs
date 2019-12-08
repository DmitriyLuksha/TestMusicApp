using System;
using TestMusicAppServer.Shared.Domain.Entities;
using TestMusicAppServer.User.Domain.Helpers;

namespace TestMusicAppServer.User.Domain.Entities
{
    public class User : BaseEntity
    {
        private User() { }

        public User(Guid id,
            string email,
            string username,
            string password)
        {
            this.Id = id;
            this.Email = email;
            this.Username = username;
            this.Password = PasswordHashProvider.ComputeHash(password);
        }

        public string Email { get; private set; }

        public string Username { get; private set; }

        public string Password { get; private set; }
    }
}
