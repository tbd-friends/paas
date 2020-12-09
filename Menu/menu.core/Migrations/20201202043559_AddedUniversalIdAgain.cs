using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gamer.Menu.Core.Migrations
{
    public partial class AddedUniversalIdAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UID",
                table: "Menus",
                nullable: false,
                defaultValueSql: "newid()");

            migrationBuilder.AddColumn<Guid>(
                name: "UID",
                table: "Items",
                nullable: false,
                defaultValueSql: "newid()");

            migrationBuilder.AddColumn<Guid>(
                name: "UID",
                table: "Categories",
                nullable: false,
                defaultValueSql: "newid()");
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
