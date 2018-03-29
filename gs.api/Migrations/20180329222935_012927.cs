using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace gs.api.Migrations
{
    public partial class _012927 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IeOrganizations");

            migrationBuilder.DropTable(
                name: "LtdOrganizations");

            migrationBuilder.DropColumn(
                name: "TokenExpireDate",
                table: "Users");

            migrationBuilder.AddColumn<long>(
                name: "OrganizationId",
                table: "Goods",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    OrganizationId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Address = table.Column<string>(maxLength: 500, nullable: true),
                    FullName = table.Column<string>(maxLength: 50, nullable: true),
                    Inn = table.Column<string>(maxLength: 50, nullable: true),
                    Phone = table.Column<string>(maxLength: 50, nullable: true),
                    TradeMark = table.Column<string>(maxLength: 50, nullable: false),
                    UseVat = table.Column<bool>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.OrganizationId);
                    table.ForeignKey(
                        name: "FK_Organizations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Goods_OrganizationId",
                table: "Goods",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_UserId",
                table: "Organizations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Goods_Organizations_OrganizationId",
                table: "Goods",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goods_Organizations_OrganizationId",
                table: "Goods");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Goods_OrganizationId",
                table: "Goods");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Goods");

            migrationBuilder.AddColumn<DateTime>(
                name: "TokenExpireDate",
                table: "Users",
                nullable: true);

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
                    UseVat = table.Column<bool>(nullable: false),
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
                    UseVat = table.Column<bool>(nullable: false),
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
    }
}
