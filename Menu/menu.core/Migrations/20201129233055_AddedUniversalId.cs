using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gamer.Menu.Core.Migrations
{
    public partial class AddedUniversalId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UID",
                table: "Menus",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UID",
                table: "Items",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UID",
                table: "Categories",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UID",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "UID",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "UID",
                table: "Categories");
        }
    }
}
