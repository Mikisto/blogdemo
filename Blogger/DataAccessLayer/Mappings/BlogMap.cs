using Domains;
using System.Data.Entity.ModelConfiguration;

namespace DataAccessLayer.Mappings
{
    public class BlogMap : EntityTypeConfiguration<Blog>
    {
        public BlogMap()
        {
            HasKey(p => p.Id);

            HasMany(p => p.Likes).WithRequired();
            HasMany(p => p.Comments).WithRequired();
        }
    }
}