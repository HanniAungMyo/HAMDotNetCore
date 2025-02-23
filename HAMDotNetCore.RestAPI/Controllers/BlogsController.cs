using HAMDotNetCore.RestAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HAMDotNetCore.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly AppDbContext _db;
        public BlogsController()
        {
            _db = new AppDbContext();
        }
        [HttpGet]
        public IActionResult GetBlog()
        {
            List<BlogDataModel> lst = _db.Blogs.OrderByDescending(x => x.BlogId).ToList();
            return Ok(lst);
        }


        [HttpPost]
        public IActionResult CreateBlog(BlogDataModel blog)
        {
            _db.Blogs.Add(blog);
            int result = _db.SaveChanges();
            string sts = result > 0 ? "Create Successful" : "Create Failed";
            return Ok(sts);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogDataModel blog)
        {
            BlogDataModel item = _db.Blogs.FirstOrDefault(item => item.BlogId == id);
            if (item is null)
            {
                return NotFound("No Data Found");
            }
            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;
            int result = _db.SaveChanges();
            string message = result > 0 ? "Updating Successful" : "Updating Fail";
            return Ok(message); 

        }


        [HttpDelete ("{id}")]
        public IActionResult BlogDelete(int id)
        {
            BlogDataModel? item = _db.Blogs.FirstOrDefault(item => item.BlogId == id);
            if (item is null)
            {
                return NotFound("No Data Found");
            }
           _db.Blogs.Remove(item);
            int result = _db.SaveChanges();
            string message = result > 0 ? "delete successful " : "failed delete";
            return Ok(message);
        }
    }
}
