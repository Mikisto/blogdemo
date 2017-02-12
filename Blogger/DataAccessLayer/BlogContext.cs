using DataAccessLayer.Mappings;
using Domains;
using System.Data.Entity;

namespace DataAccessLayer
{
    public class BlogContext : DbContext
    {
        public virtual DbSet<Blog> Blogs { get; set; }

        public BlogContext() : base("blogContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new LikeMap());
            modelBuilder.Configurations.Add(new CommentMap());
            modelBuilder.Configurations.Add(new BlogMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}