using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace gs.api.Migrations
{
    public partial class _190206 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "OrganizationId",
                table: "GoodCategories",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_GoodCategories_OrganizationId",
                table: "GoodCategories",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodCategories_Organizations_OrganizationId",
                table: "GoodCategories",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodCategories_Organizations_OrganizationId",
                table: "GoodCategories");

            migrationBuilder.DropIndex(
                name: "IX_GoodCategories_OrganizationId",
                table: "GoodCategories");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "GoodCategories");
        }
    }
}
