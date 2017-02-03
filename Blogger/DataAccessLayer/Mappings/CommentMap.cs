using Domains;
using System.Data.Entity.ModelConfiguration;

namespace DataAccessLayer.Mappings
{
    public class CommentMap : EntityTypeConfiguration<Comment>
    {
        public CommentMap()
        {
            HasKey(p => p.Id);
        }
    }
}