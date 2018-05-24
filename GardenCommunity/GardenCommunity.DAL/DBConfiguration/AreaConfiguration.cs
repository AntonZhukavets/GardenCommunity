using System.Data.Entity.ModelConfiguration;
using GardenCommunity.DAL.Entities;

namespace GardenCommunity.DAL.DBConfiguration
{
    class AreaConfiguration : EntityTypeConfiguration<Area>
    {
        public AreaConfiguration()        {
            
            //HasOptional(x => x.MembersAreas)
            //   .WithMany(x => x.)
            //   .HasForeignKey(x => x.MemberId);
        }
    }
}
