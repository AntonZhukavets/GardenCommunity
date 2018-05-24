﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using GardenCommunity.DAL.DBConfiguration;
using GardenCommunity.DAL.Entities;

namespace GardenCommunity.DAL
{
    public class GardenCommunityDB : DbContext
    {
        public GardenCommunityDB()
        {
            Database.CreateIfNotExists();
        }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Indication> Indications { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<MembersAreas> MembersAreas { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<GardenCommunityDB>(new DropCreateDatabaseIfModelChanges<GardenCommunityDB>());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new MemberConfiguration());
            modelBuilder.Configurations.Add(new RateConfiguration());
            modelBuilder.Configurations.Add(new PaymentConfiguration());
            modelBuilder.Configurations.Add(new MembersAreasConfiguration());            
        }
    }

}
