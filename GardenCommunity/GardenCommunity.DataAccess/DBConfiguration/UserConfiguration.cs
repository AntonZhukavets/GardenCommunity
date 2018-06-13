using GardenCommunity.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GardenCommunity.DataAccess.DBConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.UserName).IsRequired().HasMaxLength(20);
            builder.Property(p => p.Password).IsRequired().HasMaxLength(20);            
        }
    }
}
