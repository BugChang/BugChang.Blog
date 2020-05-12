using BugChang.Blog.Application.PostApp;
using BugChang.Blog.Application.PostApp.Dto;
using BugChang.Blog.Utility;
using BugChang.Blog.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BugChang.Blog.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private readonly IPostAppService _postAppService;

        public PostsController(IPostAppService postAppService)
        {
            _postAppService = postAppService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_postAppService.GetPosts());
        }

        [HttpGet("Home")]
        public IActionResult HomeList([FromQuery]PageSearchInput pageSearchInput)
        {
            return Ok(_postAppService.GetHomePosts(pageSearchInput));
        }

        [HttpGet("Sticky")]
        public IActionResult StickyList()
        {
            return Ok(_postAppService.GetStickyPosts());
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var post = _postAppService.GetPost(id);
            if (post == null)
            {
                return NotFound(CustomerError.Default("Not Found"));
            }
            return Ok(post);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Post([FromBody]PostDto postDto)
        {
            _postAppService.InsertPost(postDto);
            return CreatedAtAction("Get", new { id = postDto.Id }, postDto);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]PostDto postDto)
        {
            var post = _postAppService.GetPost(id);
            if (post == null)
            {
                return BadRequest(CustomerError.Default("Not Found"));
            }
            _postAppService.UpdatePost(postDto);
            return Ok(post);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet("{id}/FullContent")]
        public IActionResult FullContent(int id)
        {
            var post = _postAppService.GetFullContent(id);
            if (post == null)
            {
                return NotFound(CustomerError.Default("文章不存在或者尚未发布"));
            }
            return Ok(post);
        }
    }
}
