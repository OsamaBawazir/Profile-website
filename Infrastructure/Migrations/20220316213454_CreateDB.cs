using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ContactType = table.Column<int>(nullable: false),
                    ContactDesc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProfileItems",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    ProjectName = table.Column<string>(nullable: true),
                    Descreption = table.Column<string>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileItems", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    FullName = table.Column<string>(nullable: true),
                    Profile = table.Column<string>(nullable: true),
                    Avatar = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    contactID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Owners_Contact_contactID",
                        column: x => x.contactID,
                        principalTable: "Contact",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "ID", "Address", "Avatar", "FullName", "Profile", "contactID" },
                values: new object[] { new Guid("bdf66bd7-76aa-4eef-9c16-d2d59646d60a"), "Jeddah", null, "Osama Mohammed", ".NET Devloper", null });

            migrationBuilder.CreateIndex(
                name: "IX_Owners_contactID",
                table: "Owners",
                column: "contactID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "ProfileItems");

            migrationBuilder.DropTable(
                name: "Contact");
        }
    }
}
