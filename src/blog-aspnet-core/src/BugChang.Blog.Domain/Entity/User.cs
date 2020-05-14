using BugChang.Blog.Domain.ValueObject;

namespace BugChang.Blog.Domain.Entity
{
    public class User : EntityBase
    {
        public string UserName { get; set; }

        public string DisplayName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Avatar { get; set; }

        public Role Role { get; set; } = Role.Normal;

        public bool ValidatePassword(string password)
        {
            return Password.Equals(password);

        }
    }
}
