using System.Data.Entity.ModelConfiguration;
using GardenCommunity.DAL.Entities;

namespace GardenCommunity.DAL.DBConfiguration
{
    class AreaConfiguration : EntityTypeConfiguration<Area>
    {
        public AreaConfiguration()
        {
            HasRequired(x => x.Member)
               .WithMany(x => x.Areas)
               .HasForeignKey(x => x.MemberId);
        }
    }
}
