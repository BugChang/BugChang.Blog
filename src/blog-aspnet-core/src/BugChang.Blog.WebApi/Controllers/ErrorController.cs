using System;
using BugChang.Blog.Utility;
using BugChang.Blog.WebApi.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;


namespace BugChang.Blog.WebApi.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error-local-development")]
        public IActionResult ErrorLocalDevelopment(
            [FromServices] IWebHostEnvironment webHostEnvironment)
        {
            if (!webHostEnvironment.IsDevelopment())
            {
                throw new Exception("错误页配置有误,非开发环境不应该指向该路由");
            }
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            if (context.Error is CustomException exception)
            {
                return CustomError(exception);
            }
            return Problem(
                detail: context.Error.StackTrace,
                title: context.Error.Message);
        }

        [Route("/error")]
        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            if (context.Error is CustomException exception)
            {
               return CustomError(exception);
            }
            return Problem();
        }

        private IActionResult CustomError(CustomException exception)
        {
            switch (exception.ExceptionCode)
            {
                case CustomExceptionCode.NotFound:
                    return NotFound(CustomerError.Default(exception.Message));
                case CustomExceptionCode.AlreadyExist:
                    return BadRequest(CustomerError.Default(exception.Message));
                case CustomExceptionCode.Forbidden:
                    return Forbid();
                default:
                    return Problem();
            }
        }
    }
}
