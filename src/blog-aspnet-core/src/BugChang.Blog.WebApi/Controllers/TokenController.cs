using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BugChang.Blog.Application.AccountApp;
using BugChang.Blog.Application.AccountApp.Dto;
using BugChang.Blog.WebApi.Models;
using IdentityModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BugChang.Blog.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {

        private readonly IAccountAppService _accountAppService;
        private readonly IConfiguration _configuration;

        public TokenController(IAccountAppService accountAppService, IConfiguration configuration)
        {
            _accountAppService = accountAppService;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Post([FromBody]LoginInput loginInput)
        {
            var user=_accountAppService.CheckLogin(loginInput.UserNameOrEmail, loginInput.Password);
            if (user==null)
            {
                return BadRequest(CustomerError.Default("用户名或密码错误"));
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("JwtSetting:SecurityKey").Value);
            var authTime = DateTime.UtcNow;
            var expiresAt = authTime.AddSeconds(Convert.ToInt64(_configuration.GetSection("JwtSetting:ExpireSeconds").Value));
            if (loginInput.RememberMe)
            {
                expiresAt = authTime.AddDays(7);
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtClaimTypes.Audience,_configuration.GetSection("JwtSetting:Audience").Value),
                    new Claim(JwtClaimTypes.Issuer,_configuration.GetSection("JwtSetting:Issuer").Value),
                    new Claim(JwtClaimTypes.Id, user.Id.ToString()),
                    new Claim(JwtClaimTypes.Name, user.UserName),
                    new Claim(JwtClaimTypes.NickName, user.DisplayName),
                    new Claim(JwtClaimTypes.Role, user.Role)

                }),
                Expires = expiresAt,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
          
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return Ok(tokenString);
        }
    }
}
