using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using webapi_metadata.Models;
using webapi_metadata.Filters;

namespace webapi_metadata.Controllers
{
    public class BlogController : ApiController
    {
        private readonly IBlogRepository blogRepo = new BlogRepository();

        [CustomQueryableAttribute]
        public IQueryable<Blog> GetBlogs()
        {
            return blogRepo.GetAll();
        }

        public Blog GetBlog(int id)
        {
            return blogRepo.Get(id);
        }
     }
}