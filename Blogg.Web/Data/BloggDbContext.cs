using Blogg.Web.Models.Domian;
using Microsoft.EntityFrameworkCore;

namespace Blogg.Web.Data
{
    public class BloggDbContext : DbContext
    {
        public BloggDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<Tag> Tags { get; set; }
    }
}
