using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Todo.Domain.Infra.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User",
                table: "TB_TODO",
                newName: "USER");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "TB_TODO",
                newName: "TITLE");

            migrationBuilder.RenameColumn(
                name: "Done",
                table: "TB_TODO",
                newName: "DONE");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "TB_TODO",
                newName: "DATE");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TB_TODO",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_TB_TODO_User",
                table: "TB_TODO",
                newName: "IX_TB_TODO_USER");

            migrationBuilder.CreateTable(
                name: "TB_USER",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "varchar(160)", maxLength: 160, nullable: true),
                    EMAIL = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true),
                    PASSWORD = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USER", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_USER");

            migrationBuilder.RenameColumn(
                name: "USER",
                table: "TB_TODO",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "TITLE",
                table: "TB_TODO",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "DONE",
                table: "TB_TODO",
                newName: "Done");

            migrationBuilder.RenameColumn(
                name: "DATE",
                table: "TB_TODO",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "TB_TODO",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_TB_TODO_USER",
                table: "TB_TODO",
                newName: "IX_TB_TODO_User");
        }
    }
}
