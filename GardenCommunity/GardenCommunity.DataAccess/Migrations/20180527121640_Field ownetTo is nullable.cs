using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GardenCommunity.DataAccess.Migrations
{
    public partial class FieldownetToisnullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HasElectricity = table.Column<bool>(nullable: false),
                    IsPrivate = table.Column<bool>(nullable: false),
                    ParentAreaId = table.Column<int>(nullable: true),
                    Square = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Areas_Areas_ParentAreaId",
                        column: x => x.ParentAreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Indications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CurrentIndication = table.Column<double>(nullable: false),
                    LastIndication = table.Column<double>(nullable: false),
                    LoosesPercent = table.Column<double>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdditionalInfo = table.Column<string>(nullable: true),
                    Address = table.Column<string>(maxLength: 150, nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    IsActiveMember = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    MiddleName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BankCollectionPercent = table.Column<double>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    FinePercent = table.Column<double>(nullable: false),
                    RateName = table.Column<string>(maxLength: 50, nullable: false),
                    RateValue = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MembersAreas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AreaId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    OwnedFrom = table.Column<DateTime>(nullable: false),
                    OwnedTo = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembersAreas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MembersAreas_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MembersAreas_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateOfPayment = table.Column<DateTime>(nullable: false),
                    IndicationId = table.Column<int>(nullable: true),
                    MemberId = table.Column<int>(nullable: false),
                    PaidFor = table.Column<double>(nullable: false),
                    RateId = table.Column<int>(nullable: false),
                    ToPay = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Indications_IndicationId",
                        column: x => x.IndicationId,
                        principalTable: "Indications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Rates_RateId",
                        column: x => x.RateId,
                        principalTable: "Rates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Areas_ParentAreaId",
                table: "Areas",
                column: "ParentAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_MembersAreas_AreaId",
                table: "MembersAreas",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_MembersAreas_MemberId",
                table: "MembersAreas",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_IndicationId",
                table: "Payments",
                column: "IndicationId",
                unique: true,
                filter: "[IndicationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_MemberId",
                table: "Payments",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_RateId",
                table: "Payments",
                column: "RateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MembersAreas");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Indications");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Rates");
        }
    }
}
