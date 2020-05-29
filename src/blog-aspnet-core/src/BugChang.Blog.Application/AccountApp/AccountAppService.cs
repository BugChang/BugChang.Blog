using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BugChang.Blog.Application.AccountApp.Dto;
using BugChang.Blog.Domain.Entity;
using BugChang.Blog.Domain.Interface;
using BugChang.Blog.Domain.Service;

namespace BugChang.Blog.Application.AccountApp
{
    public class AccountAppService : IAccountAppService
    {
        private readonly IRepository<User> _userRepository;
        private readonly UserService _userService;
        private readonly IMapper _mapper;

        public AccountAppService(IRepository<User> userRepository, IMapper mapper, UserService userService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userService = userService;
        }

        public UserDto CheckLogin(string usernameOrEmail, string password)
        {
            usernameOrEmail = usernameOrEmail.ToLower();
            var user = _userRepository.GetQueryable(u => u.UserName.ToLower().Equals(usernameOrEmail) || u.Email.ToLower().Equals(usernameOrEmail))
                .FirstOrDefault();
            if (user != null && user.ValidatePassword(password))
            {
                return _mapper.Map<UserDto>(user);
            }

            return null;
        }

        public void Register(RegisterInput registerInput)
        {
            var user = _mapper.Map<User>(registerInput);
            _userService.AddNewUser(user);
        }
    }
}
