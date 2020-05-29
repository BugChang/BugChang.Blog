using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugChang.Blog.Domain.Entity;
using BugChang.Blog.Domain.Interface;
using BugChang.Blog.Utility;

namespace BugChang.Blog.Domain.Service
{
    public class UserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddNewUser(User user)
        {
            if (ExistEmail(user.Email))
            {
                throw new CustomException(CustomExceptionCode.AlreadyExist,"这个邮箱已经被注册了");
            }

            if (ExistUserName(user.UserName))
            {
                throw new CustomException(CustomExceptionCode.AlreadyExist, "这个用户名已经被注册了");
            }

            _userRepository.Add(user);
        }

        public bool ExistEmail(string email)
        {
            return _userRepository.GetQueryable(u => u.Email == email).Any();
        }

        public bool ExistUserName(string userName)
        {
            return _userRepository.GetQueryable(u => u.UserName == userName).Any();
        }
    }
}
