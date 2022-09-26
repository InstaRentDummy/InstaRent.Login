using System;
using Volo.Abp.Domain.Entities;

namespace InstaRent.Login.Users
{
    public class User : AggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        private User()
        {
        }

        internal User(Guid id, string name, string email, string password, string role) : base(id)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Role = role;
        }

    }
}
