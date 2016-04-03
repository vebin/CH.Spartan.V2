using System.ComponentModel.DataAnnotations;

namespace CH.Spartan.Web.Models.Account
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}