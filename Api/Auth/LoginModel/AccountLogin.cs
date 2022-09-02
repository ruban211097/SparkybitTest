using System.ComponentModel.DataAnnotations;

namespace Api.Auth.LoginModel
{
    public class AccountLogin
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
