using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugChang.Blog.Application.Core;
using BugChang.Blog.Application.PostApp;
using BugChang.Blog.Application.PostApp.Dto;
using BugChang.Blog.Utility;
using BugChang.Blog.WebApi.Models;
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

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]PostDto postDto)
        {
            _postAppService.InsertPost(postDto);
            return CreatedAtAction("Get", new { id = postDto.Id }, postDto);
        }

        // PUT api/<controller>/5
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

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet("{id}/FullContent")]
        public IActionResult FullContent(int id)
        {
            var post = _postAppService.GetPost(id);
            if (!post.IsPublish)
            {
                return NotFound(CustomerError.Default("文章不存在或者尚未发布"));
            }

            return Ok(post);
        }
    }
}
