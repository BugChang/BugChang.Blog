using System;
using System.IO;
using BugChang.Blog.Utility;
using BugChang.Blog.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BugChang.Blog.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class FilesController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IConfiguration _configuration;
        public FilesController(IWebHostEnvironment environment, IConfiguration configuration)
        {
            _environment = environment;
            _configuration = configuration;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Post(IFormFile formFile)
        {
            if (formFile == null || formFile.Length == 0)
            {
                return BadRequest(CustomerError.Default("上传文件不能为空"));
            }

            var filePath = GetUploadFilePath(formFile.FileName);

            using (var stream = new MemoryStream())
            {
                formFile.CopyTo(stream);
                ImageHelper.CompressImage(stream, filePath);
            }

            var imgUrl = GetImgUrl(filePath);


            return Created(imgUrl, new { imgUrl });
        }

        private string GetUploadFilePath(string sourceFileName)
        {
            var extension = Path.GetExtension(sourceFileName);
            var destFileName = DateTimeHelper.GetTimeStamp() + extension;
            var filePath = $"{_environment.WebRootPath}/Upload/{DateTime.Now:yyyy/MM/dd}/{destFileName}";
            var fileDir = filePath.Replace(destFileName, "");
            DirectoryHelper.Create(fileDir);
            return filePath;
        }


        private string GetImgUrl(string filePath)
        {
            var relativePath = filePath.Replace(_environment.WebRootPath, "");
            var imgUrl = $"{Request.Scheme}://{Request.Host}{relativePath}";
            var domain = _configuration.GetSection("Domain").Value;
            if (!string.IsNullOrWhiteSpace(domain))
            {
                imgUrl = $"{domain}{relativePath}";
            }

            return imgUrl;
        }
    }
}
