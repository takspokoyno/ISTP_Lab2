using Microsoft.EntityFrameworkCore;

namespace Labka2.Models
{
    public class SocialMediaContext: DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Sub> Subs { get; set; }
        public virtual DbSet<Public> Publics { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public SocialMediaContext(DbContextOptions<SocialMediaContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
