using DotNetTrainingBatch3.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTrainingBatch3.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _db;
        public BlogController()
        {
            _db = new AppDbContext();
        }
        [HttpGet]
        public IActionResult GetBlogs()
        {
            List<BlogModel> lst = _db.Blogs.OrderByDescending(x => x.BlogID).ToList();
            return Ok(lst);
        }
        [HttpGet(template:"{id}")]
        public IActionResult GetBlog(int id)
        {
            BlogModel? item = _db.Blogs.FirstOrDefault(item => item.BlogID == id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            return Ok(item);
        }
        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            _db.Blogs.Add(blog);
            int result = _db.SaveChanges();
            string message = result > 0 ? "Saving Successful." : "Saving failed.";
            return Ok(message);
        }
        //[HttpGet]
        //public IActionResult GetBlogs()
        //{
        //    return Ok("GetBlogs");
        //}
        [HttpPut(template:"{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {
            BlogModel? item = _db.Blogs.FirstOrDefault(item => item.BlogID == id);
            if (item is null)
            {
                return NotFound("No Data Found.");
            }
            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;
            int result = _db.SaveChanges();

            string message = result > 0 ? "Updating successful." : "Updating Failed.";
            return Ok(message);
        }
        [HttpDelete(template:"{id}")]
        public IActionResult DeleteBlog(int id)
        {
            BlogModel? item = _db.Blogs.FirstOrDefault(item => item.BlogID == id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            _db.Blogs.Remove(item);
            int result = _db.SaveChanges();
            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            return Ok(message);
        }
    }
}
