using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace gs.api.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "IeOrganizations",
                columns: table => new
                {
                    OrganizationId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Address = table.Column<string>(maxLength: 500, nullable: true),
                    FullName = table.Column<string>(maxLength: 50, nullable: true),
                    Inn = table.Column<string>(maxLength: 50, nullable: true),
                    Phone = table.Column<string>(maxLength: 50, nullable: true),
                    TradeMark = table.Column<string>(maxLength: 50, nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IeOrganizations", x => x.OrganizationId);
                    table.ForeignKey(
                        name: "FK_IeOrganizations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LtdOrganizations",
                columns: table => new
                {
                    OrganizationId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Address = table.Column<string>(maxLength: 500, nullable: true),
                    FullName = table.Column<string>(maxLength: 50, nullable: true),
                    Inn = table.Column<string>(maxLength: 50, nullable: true),
                    Kpp = table.Column<string>(maxLength: 50, nullable: true),
                    Phone = table.Column<string>(maxLength: 50, nullable: true),
                    ShortName = table.Column<string>(maxLength: 50, nullable: true),
                    TradeMark = table.Column<string>(maxLength: 50, nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LtdOrganizations", x => x.OrganizationId);
                    table.ForeignKey(
                        name: "FK_LtdOrganizations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IeOrganizations_UserId",
                table: "IeOrganizations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LtdOrganizations_UserId",
                table: "LtdOrganizations",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IeOrganizations");

            migrationBuilder.DropTable(
                name: "LtdOrganizations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
