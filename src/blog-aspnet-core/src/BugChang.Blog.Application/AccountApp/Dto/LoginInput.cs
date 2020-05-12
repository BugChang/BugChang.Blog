namespace BugChang.Blog.Application.AccountApp.Dto
{
   public class LoginInput
    {
        public string UserNameOrEmail { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
