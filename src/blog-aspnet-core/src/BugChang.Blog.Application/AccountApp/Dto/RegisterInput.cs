using System.ComponentModel.DataAnnotations;

namespace BugChang.Blog.Application.AccountApp.Dto
{
   public class RegisterInput
    {
        [EmailAddress]
        public string Email { get; set; }

        public string UserName { get; set; }

        public string DisplayName { get; set; }

        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public bool IsAgree { get; set; }
    }
}
