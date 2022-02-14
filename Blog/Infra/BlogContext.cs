using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infra
{
    public class BlogContext : DbContext
    {
        public DbSet<Post>? Posts { get; set; }
        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }
       
    }
}
