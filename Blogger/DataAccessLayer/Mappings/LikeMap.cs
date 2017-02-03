using Domains;
using System.Data.Entity.ModelConfiguration;

namespace DataAccessLayer.Mappings
{
    public class LikeMap : EntityTypeConfiguration<Like>
    {
        public LikeMap()
        {
            HasKey(p => p.Id);
        }
    }
}