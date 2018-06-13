using GardenCommunity.DataAccess.DBConfiguration;
using GardenCommunity.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GardenCommunity.DataAccess
{
    public class GardenCommunityContext : DbContext
    {
        public GardenCommunityContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Indication> Indications { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<MembersAreas> MembersAreas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {                       
            modelBuilder.ApplyConfiguration(new MemberConfiguration());
            modelBuilder.ApplyConfiguration(new MembersAreasConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
            modelBuilder.ApplyConfiguration(new RateConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");            
            var config = builder.Build();
            var connectionString = config.GetConnectionString("GardenCommunityConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
