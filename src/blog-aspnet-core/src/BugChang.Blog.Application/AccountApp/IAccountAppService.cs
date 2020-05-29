using BugChang.Blog.Application.AccountApp.Dto;

namespace BugChang.Blog.Application.AccountApp
{
    public interface IAccountAppService
    {
        UserDto CheckLogin(string usernameOrEmail, string password);

        void Register(RegisterInput registerInput);
    }
}
