using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Library.DAL.Migrations
{
    public partial class _9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeOfPublication",
                table: "Magazines");

            migrationBuilder.DropColumn(
                name: "TypeOfCover",
                table: "Brochures");

            migrationBuilder.DropColumn(
                name: "TypeOfPublication",
                table: "Brochures");

            migrationBuilder.DropColumn(
                name: "TypeOfPublication",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "PublicationType",
                table: "Magazines",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CoverType",
                table: "Brochures",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PublicationType",
                table: "Brochures",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PublicationType",
                table: "Books",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicationType",
                table: "Magazines");

            migrationBuilder.DropColumn(
                name: "CoverType",
                table: "Brochures");

            migrationBuilder.DropColumn(
                name: "PublicationType",
                table: "Brochures");

            migrationBuilder.DropColumn(
                name: "PublicationType",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "TypeOfPublication",
                table: "Magazines",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeOfCover",
                table: "Brochures",
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
    }
}
