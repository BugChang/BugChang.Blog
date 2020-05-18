using Microsoft.AspNetCore.Mvc;


namespace BugChang.Blog.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
       
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
    }
}
