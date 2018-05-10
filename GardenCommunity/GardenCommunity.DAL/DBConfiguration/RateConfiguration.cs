using System.Data.Entity.ModelConfiguration;
using GardenCommunity.DAL.Entities;

namespace GardenCommunity.DAL.DBConfiguration
{
    public class RateConfiguration : EntityTypeConfiguration<Rate>
    {
        public RateConfiguration()
        {
            Property(p => p.RateName).IsRequired().HasMaxLength(50);
            HasMany(x => x.Payments).WithRequired(x => x.Rate);            
        }
    }
}
