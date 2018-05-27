using GardenCommunity.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GardenCommunity.DataAccess.DBConfiguration
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Address).IsRequired().HasMaxLength(150);
            builder.Property(p => p.Phone).IsRequired().HasMaxLength(20);
        }
    }
}



