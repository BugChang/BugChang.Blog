using System.Collections.Generic;
using BugChang.Blog.Application.CategoryApp;
using BugChang.Blog.Application.CategoryApp.Dto;
using BugChang.Blog.Domain.Entity;
using BugChang.Blog.Utility;
using BugChang.Blog.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BugChang.Blog.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryAppService _categoryAppService;
        

        public CategoriesController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            var categories = _categoryAppService.GetCategories();
            return Ok(categories);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var category = _categoryAppService.GetCategory(id);
            if (category == null)
            {
                return NotFound(CustomerError.Default("该分类不存在"));
            }

            return Ok(category);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Post([FromBody]CategoryDto categoryDto)
        {
            _categoryAppService.InsertCategory(categoryDto);
            return CreatedAtAction("Get", new { id = categoryDto.Id }, categoryDto);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]CategoryDto categoryDto)
        {
            _categoryAppService.UpdateCategory(categoryDto);
            return Ok(categoryDto);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_categoryAppService.GetCategory(id) == null)
            {
                return BadRequest(CustomerError.Default("该分类不存在"));
            }
            _categoryAppService.DeleteCategory(id);
            return NoContent();
        }

        [HttpGet("Colors")]
        public ActionResult Color()
        {
            var colors = _categoryAppService.GetCategoryColors();
            return Ok(colors);
        }

        [HttpGet("Nav")]
        public IActionResult Nav()
        {
            var categories = _categoryAppService.GetNavList();
            return Ok(categories);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}/Posts")]
        public IActionResult Posts(int id,PageSearchInput pageSearchInput)
        {
           var posts= _categoryAppService.GetPosts(id, pageSearchInput);
           return Ok(posts);
        }

    }
}
