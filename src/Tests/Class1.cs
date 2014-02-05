using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; } 
    }

    public class Blog
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Url { get; set; }
    }
}
