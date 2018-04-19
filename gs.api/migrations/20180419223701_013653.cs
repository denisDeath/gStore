using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace gs.api.Migrations
{
    public partial class _013653 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoolSpecificationValues",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OrganizationId = table.Column<long>(nullable: false),
                    Value = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoolSpecificationValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoolSpecificationValues_Specifications_Id",
                        column: x => x.Id,
                        principalTable: "Specifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoolSpecificationValues_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColorSpecificationValues",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Blue = table.Column<int>(nullable: false),
                    Green = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: false),
                    Red = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorSpecificationValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColorSpecificationValues_Specifications_Id",
                        column: x => x.Id,
                        principalTable: "Specifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColorSpecificationValues_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NumberSpecificationValues",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OrganizationId = table.Column<long>(nullable: false),
                    Value = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumberSpecificationValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NumberSpecificationValues_Specifications_Id",
                        column: x => x.Id,
                        principalTable: "Specifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NumberSpecificationValues_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StringSpecificationValues",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OrganizationId = table.Column<long>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StringSpecificationValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StringSpecificationValues_Specifications_Id",
                        column: x => x.Id,
                        principalTable: "Specifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StringSpecificationValues_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoolSpecificationValues_OrganizationId",
                table: "BoolSpecificationValues",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ColorSpecificationValues_OrganizationId",
                table: "ColorSpecificationValues",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_NumberSpecificationValues_OrganizationId",
                table: "NumberSpecificationValues",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_StringSpecificationValues_OrganizationId",
                table: "StringSpecificationValues",
                column: "OrganizationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoolSpecificationValues");

            migrationBuilder.DropTable(
                name: "ColorSpecificationValues");

            migrationBuilder.DropTable(
                name: "NumberSpecificationValues");

            migrationBuilder.DropTable(
                name: "StringSpecificationValues");
        }
    }
}
