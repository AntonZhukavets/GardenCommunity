using GardenCommunity.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GardenCommunity.DataAccess.DBConfiguration
{
    class MembersAreasConfiguration : IEntityTypeConfiguration<MembersAreas>
    {
        public void Configure(EntityTypeBuilder<MembersAreas> builder)
        {            
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Member).WithMany(x => x.MembersAreas).HasForeignKey(x => x.MemberId);
            builder.HasOne(x => x.Area).WithMany(x => x.MembersAreas).HasForeignKey(x => x.AreaId);
        }
    }
}
