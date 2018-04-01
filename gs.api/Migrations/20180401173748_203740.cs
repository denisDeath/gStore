using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace gs.api.Migrations
{
    public partial class _203740 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stores",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Stores",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
