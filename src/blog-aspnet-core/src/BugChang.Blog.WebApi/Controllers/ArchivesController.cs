using BugChang.Blog.Application.ArchiveApp;
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
    }
}
