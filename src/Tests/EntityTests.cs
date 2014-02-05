using System.Linq;
using FluentAssertions;
using Xunit;

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

        [Fact]
        public void try_first_migration()
        {
            var bloggingContext = new BloggingContext();
            var blog = bloggingContext.Blogs.First();
            blog.Url = "this is my URL";
            bloggingContext.SaveChanges();

        }
    }
}