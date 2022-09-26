using System.ComponentModel.DataAnnotations;

namespace InstaRent.Login.Users
{
    public class CreateUpdateUserDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [StringLength(64)]
        public string Email { get; set; }

        [Required]
        [StringLength(64)]
        public string Password { get; set; }

        [Required]
        [StringLength(32)]
        public string Role { get; set; }
    }

    public class LoginUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
