using System.ComponentModel.DataAnnotations;

namespace AuthenticationWitthJWT.Entitys
{
    public class User
    {
        [Key]
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
