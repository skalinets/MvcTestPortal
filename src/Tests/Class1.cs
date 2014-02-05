using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace Tests
{
    
    public class EntityTests
    {
        [Fact]
        public void hello()
        {
            var blog = new Blog {Name = "this is the blog"};
            var bloggingContext = new BloggingContext();
            bloggingContext.Blogs.Add(blog);
            bloggingContext.SaveChanges();
        }

        [Fact]
        public void read_data()
        {
            var bloggingContext = new BloggingContext();
            bloggingContext.Blogs
                .Where(b => b.Name.Contains("foo")).Should().BeEmpty();
            bloggingContext.Blogs
                .Where(b => b.Name.Contains("the")).Should().NotBeEmpty();

//            bloggingContext.Blogs.Should().NotBeEmpty();
        }
    }

    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; } 
    }

    public class Blog
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
