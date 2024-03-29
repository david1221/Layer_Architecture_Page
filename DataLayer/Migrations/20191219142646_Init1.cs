﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class Init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Directories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Html = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Html = table.Column<string>(nullable: true),
                    DirectoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_Directories_DirectoryId",
                        column: x => x.DirectoryId,
                        principalTable: "Directories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Directories",
                columns: new[] { "Id", "Html", "Title" },
                values: new object[] { 1, "<b>Directory Contexn</b>", "First Directory" });

            migrationBuilder.InsertData(
                table: "Directories",
                columns: new[] { "Id", "Html", "Title" },
                values: new object[] { 2, "<b>Directory Contexn</b>", "Second Directory" });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "DirectoryId", "Html", "Title" },
                values: new object[] { 1, 1, "<b>Materials Contexn</b>", "First Materials" });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "DirectoryId", "Html", "Title" },
                values: new object[] { 3, 1, "<b>Materials Contexn</b>", "First Materials" });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "DirectoryId", "Html", "Title" },
                values: new object[] { 2, 2, "<b>Materials Contexn</b>", "First Materials" });

            migrationBuilder.CreateIndex(
                name: "IX_Materials_DirectoryId",
                table: "Materials",
                column: "DirectoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Directories");
        }
    }
}
