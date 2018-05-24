using GardenCommunity.DAL.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GardenCommunity.DAL.DBConfiguration
{
    class MembersAreasConfiguration : EntityTypeConfiguration<MembersAreas>
    {
        public MembersAreasConfiguration()
        {
            HasKey(x => x.Id);
            //HasKey(x => x.MemberId);
            //HasKey(x => x.AreaId);
            HasRequired(x => x.Member).WithMany(x => x.MembersAreas).HasForeignKey(x => x.MemberId);
            HasRequired(x => x.Area).WithMany(x => x.MembersAreas).HasForeignKey(x => x.AreaId);
        }
    }
}
