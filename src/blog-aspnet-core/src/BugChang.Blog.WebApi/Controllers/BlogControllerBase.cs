using System;
using System.Linq;
using BugChang.Blog.WebApi.Models;
using IdentityModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BugChang.Blog.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class BlogControllerBase : Controller
    {
        protected AccountInfo GetAccountInfo()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return null;
            }
            var claims = HttpContext.User.Claims.ToList();
            var accountInfo = new AccountInfo
            {
                UserId = int.Parse(claims.FirstOrDefault(a => a.Type == JwtClaimTypes.Id)?.Value ??
                               throw new InvalidOperationException("当前账号ID有误")),
                Email = claims.FirstOrDefault(a => a.Type == JwtClaimTypes.Email)?.Value,
                Name = claims.FirstOrDefault(a => a.Type == JwtClaimTypes.Name)?.Value,
                NickName = claims.FirstOrDefault(a => a.Type == JwtClaimTypes.NickName)?.Value,
                Role = claims.FirstOrDefault(a => a.Type == JwtClaimTypes.Role)?.Value,
            };
            return accountInfo;
        }
    }
}
