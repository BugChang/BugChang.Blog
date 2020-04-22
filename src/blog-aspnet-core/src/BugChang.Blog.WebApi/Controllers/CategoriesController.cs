using System.Collections.Generic;
using BugChang.Blog.Application.CategoryApp;
using BugChang.Blog.Domain.Entity;
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
        public IEnumerable<Category> Get()
        {
            return _categoryAppService.GetCategories();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult<Category> Get(int id)
        {
            var category = _categoryAppService.GetCategory(id);
            if (category == null)
            {
                return NotFound(new { error = "该分类不存在" });
            }

            return Ok(category);
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]Category category)
        {
            _categoryAppService.InsertCategory(category);
            return CreatedAtAction("Get", new { id = category.Id }, category);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult<Category> Put(int id, [FromBody]Category category)
        {
            if (_categoryAppService.GetCategory(id) == null)
            {
                return BadRequest(new { error = "该分类不存在" });
            }
            _categoryAppService.UpdateCategory(category);
            return Ok(category);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_categoryAppService.GetCategory(id) == null)
            {
                return BadRequest(new { error = "该分类不存在" });
            }
            _categoryAppService.DeleteCategory(id);
            return NoContent();
        }
    }
}
