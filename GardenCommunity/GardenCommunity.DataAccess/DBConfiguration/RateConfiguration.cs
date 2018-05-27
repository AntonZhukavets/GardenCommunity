using GardenCommunity.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GardenCommunity.DataAccess.DBConfiguration
{
    public class RateConfiguration : IEntityTypeConfiguration<Rate>
    {
        public void Configure(EntityTypeBuilder<Rate> builder)
        {
            builder.Property(p => p.RateName).IsRequired().HasMaxLength(50);
            builder.HasMany(x => x.Payments).WithOne(x => x.Rate);
        }
    }
}
