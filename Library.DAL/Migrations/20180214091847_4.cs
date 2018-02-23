using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Library.DAL.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookPublisher_Books_BookId",
                table: "BookPublisher");

            migrationBuilder.AddForeignKey(
                name: "FK_BookPublisher_Books_BookId",
                table: "BookPublisher",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookPublisher_Books_BookId",
                table: "BookPublisher");

            migrationBuilder.AddForeignKey(
                name: "FK_BookPublisher_Books_BookId",
                table: "BookPublisher",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
