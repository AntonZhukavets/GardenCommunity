using GardenCommunity.DAL.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GardenCommunity.DAL.DBConfiguration
{
    public class PaymentConfiguration : EntityTypeConfiguration<Payment>
    {
        public PaymentConfiguration()
        {
            HasRequired(x => x.Indication)
                .WithRequiredPrincipal(x => x.Payment);              
        }
    }
}
