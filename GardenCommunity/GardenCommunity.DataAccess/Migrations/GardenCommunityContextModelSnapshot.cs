﻿// <auto-generated />
using GardenCommunity.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace GardenCommunity.DataAccess.Migrations
{
    [DbContext(typeof(GardenCommunityContext))]
    partial class GardenCommunityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GardenCommunity.DataAccess.Entities.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("HasElectricity");

                    b.Property<bool>("IsPrivate");

                    b.Property<int?>("ParentAreaId");

                    b.Property<int>("Square");

                    b.HasKey("Id");

                    b.HasIndex("ParentAreaId");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("GardenCommunity.DataAccess.Entities.Indication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("CurrentIndication");

                    b.Property<double>("LastIndication");

                    b.Property<double>("LoosesPercent");

                    b.Property<int>("Month");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.ToTable("Indications");
                });

            modelBuilder.Entity("GardenCommunity.DataAccess.Entities.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdditionalInfo");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("IsActiveMember");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("MiddleName");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("GardenCommunity.DataAccess.Entities.MembersAreas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AreaId");

                    b.Property<int>("MemberId");

                    b.Property<DateTime?>("OwnedFrom");

                    b.Property<DateTime?>("OwnedTo");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("MemberId");

                    b.ToTable("MembersAreas");
                });

            modelBuilder.Entity("GardenCommunity.DataAccess.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfPayment");

                    b.Property<int?>("IndicationId");

                    b.Property<int>("MemberId");

                    b.Property<double>("PaidFor");

                    b.Property<int>("RateId");

                    b.Property<double>("ToPay");

                    b.HasKey("Id");

                    b.HasIndex("IndicationId")
                        .IsUnique()
                        .HasFilter("[IndicationId] IS NOT NULL");

                    b.HasIndex("MemberId");

                    b.HasIndex("RateId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("GardenCommunity.DataAccess.Entities.Rate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("BankCollectionPercent");

                    b.Property<DateTime>("Date");

                    b.Property<double>("FinePercent");

                    b.Property<string>("RateName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<double>("RateValue");

                    b.HasKey("Id");

                    b.ToTable("Rates");
                });

            modelBuilder.Entity("GardenCommunity.DataAccess.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("GardenCommunity.DataAccess.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("RoleId");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GardenCommunity.DataAccess.Entities.Area", b =>
                {
                    b.HasOne("GardenCommunity.DataAccess.Entities.Area", "ParentArea")
                        .WithMany()
                        .HasForeignKey("ParentAreaId");
                });

            modelBuilder.Entity("GardenCommunity.DataAccess.Entities.MembersAreas", b =>
                {
                    b.HasOne("GardenCommunity.DataAccess.Entities.Area", "Area")
                        .WithMany("MembersAreas")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GardenCommunity.DataAccess.Entities.Member", "Member")
                        .WithMany("MembersAreas")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GardenCommunity.DataAccess.Entities.Payment", b =>
                {
                    b.HasOne("GardenCommunity.DataAccess.Entities.Indication", "Indication")
                        .WithOne("Payment")
                        .HasForeignKey("GardenCommunity.DataAccess.Entities.Payment", "IndicationId");

                    b.HasOne("GardenCommunity.DataAccess.Entities.Member", "Member")
                        .WithMany("Payments")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GardenCommunity.DataAccess.Entities.Rate", "Rate")
                        .WithMany("Payments")
                        .HasForeignKey("RateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GardenCommunity.DataAccess.Entities.User", b =>
                {
                    b.HasOne("GardenCommunity.DataAccess.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
