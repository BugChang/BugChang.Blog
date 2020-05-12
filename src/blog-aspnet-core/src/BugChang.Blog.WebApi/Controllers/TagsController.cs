using BugChang.Blog.Application.TagApp;
using BugChang.Blog.Utility;
using Microsoft.AspNetCore.Mvc;


namespace BugChang.Blog.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TagsController : Controller
    {

        private readonly ITagAppService _tagAppService;

        public TagsController(ITagAppService tagAppService)
        {
            _tagAppService = tagAppService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var tags = _tagAppService.GetTags();
            return Ok(tags);
        }

        // GET api/<controller>/5
        [HttpGet("{name}/Posts")]
        public IActionResult Posts(string name, [FromQuery]PageSearchInput pageSearchInput)
        {
            var posts = _tagAppService.GetPosts(name, pageSearchInput);
            return Ok(posts);
        }
    }
}
