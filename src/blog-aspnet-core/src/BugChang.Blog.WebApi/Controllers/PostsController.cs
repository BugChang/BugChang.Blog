using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugChang.Blog.Application.PostApp;
using BugChang.Blog.Application.PostApp.Dto;
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
        public ActionResult Get()
        {
            return NoContent();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]PostDto postDto)
        {
            _postAppService.InsertCategory(postDto);
            return CreatedAtAction("Get", new { id = postDto.Id }, postDto);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
