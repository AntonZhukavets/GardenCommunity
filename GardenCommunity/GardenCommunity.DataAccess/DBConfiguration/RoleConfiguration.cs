using GardenCommunity.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GardenCommunity.DataAccess.DBConfiguration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.HasMany(p => p.Users).WithOne(p => p.Role);
        }
    }
}
