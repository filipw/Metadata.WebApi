using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapi_metadata.Models
{
    public interface IBlogRepository
    {
        IQueryable<Blog> GetAll();
        Blog Get(int id);
        Blog Add(Blog url);
    }

    public class BlogRepository : IBlogRepository
    {
        private List<Blog> blogs = new List<Blog>();
        private int nextId = 1;

        public BlogRepository()
        {
            this.Add(new Blog()
            {
                BlogId = 1,
                Address = "http://www.strathweb.com/",
                Author = "Filip W"
            });
            this.Add(new Blog()
            {
                BlogId = 1,
                Address = "http://west-wind.com/weblog/",
                Author = "Rick Strahl"
            });
            this.Add(new Blog()
            {
                BlogId = 1,
                Address = "http://byterot.blogspot.com",
                Author = "Aliostad"
            });
        }

        public IQueryable<Blog> GetAll()
        {
            return this.blogs.AsQueryable();
        }
        public Blog Get(int id)
        {
            return this.blogs.Find(i => i.BlogId == id);
        }
        public Blog Add(Blog blog)
        {
            blog.BlogId = nextId++;
            this.blogs.Add(blog);
            return blog;
        }
    }
}