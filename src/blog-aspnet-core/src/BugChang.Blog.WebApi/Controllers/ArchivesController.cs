using BugChang.Blog.Application.ArchiveApp;
using BugChang.Blog.Utility;
using Microsoft.AspNetCore.Mvc;


namespace BugChang.Blog.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ArchivesController : Controller
    {

        private readonly IArchiveAppService _archiveAppService;

        public ArchivesController(IArchiveAppService archiveAppService)
        {
            _archiveAppService = archiveAppService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var archives = _archiveAppService.GetArchives();
            return Ok(archives);

        }

        [HttpGet("{year}-{month}/posts")]
        public IActionResult Posts(int year,int month,[FromQuery] PageSearchInput pageSearchInput)
        {
            var posts= _archiveAppService.GetPosts(year, month, pageSearchInput);
            return Ok(posts);
        }
    }
}
