using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Library.DAL.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Magazines");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Brochures");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "TypeOfPublication",
                table: "Magazines",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeOfPublication",
                table: "Brochures",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeOfPublication",
                table: "Books",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeOfPublication",
                table: "Magazines");

            migrationBuilder.DropColumn(
                name: "TypeOfPublication",
                table: "Brochures");

            migrationBuilder.DropColumn(
                name: "TypeOfPublication",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Magazines",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Brochures",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Books",
                nullable: false,
                defaultValue: 0);
        }
    }
}
