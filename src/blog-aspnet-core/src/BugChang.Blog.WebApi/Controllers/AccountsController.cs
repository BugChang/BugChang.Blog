using System;
using System.Linq;
using BugChang.Blog.Application.AccountApp;
using BugChang.Blog.Application.AccountApp.Dto;
using BugChang.Blog.WebApi.Models;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BugChang.Blog.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : BlogControllerBase
    {


        private readonly IAccountAppService _accountAppService;

        public AccountsController(IAccountAppService accountAppService)
        {
            _accountAppService = accountAppService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]RegisterInput registerInput)
        {
            _accountAppService.Register(registerInput);
            return Ok();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var accountInfo = GetAccountInfo();
            return Ok(accountInfo);
        }
    }
}
