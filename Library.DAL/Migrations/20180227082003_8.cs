using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Library.DAL.Migrations
{
    public partial class _8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YearOfPublishing",
                table: "Magazines");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfPublishing",
                table: "Magazines",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfPublishing",
                table: "Magazines");

            migrationBuilder.AddColumn<int>(
                name: "YearOfPublishing",
                table: "Magazines",
                nullable: false,
                defaultValue: 0);
        }
    }
}
