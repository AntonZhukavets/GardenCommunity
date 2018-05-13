using System.Data.Entity.ModelConfiguration;
using GardenCommunity.DAL.Entities;

namespace GardenCommunity.DAL.DBConfiguration
{
    public class MemberConfiguration : EntityTypeConfiguration<Member>
    {
        public MemberConfiguration()
        {
            Property(p => p.LastName).IsRequired().HasMaxLength(100);
            Property(p => p.FirstName).IsRequired().HasMaxLength(100);
            Property(p => p.Address).IsRequired().HasMaxLength(150);
            Property(p => p.Phone).IsRequired().HasMaxLength(20);                  
        }
    }
}
