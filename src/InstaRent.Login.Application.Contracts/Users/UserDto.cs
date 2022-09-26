using System;
using Volo.Abp.Application.Dtos;

namespace InstaRent.Login.Users
{
    public class UserDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }
    }
}
