using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Todo.Domain.Infra.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TB_TODO_USER",
                table: "TB_TODO");

            migrationBuilder.DropColumn(
                name: "USER",
                table: "TB_TODO");

            migrationBuilder.AddColumn<Guid>(
                name: "USER_ID",
                table: "TB_TODO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_TODO_USER_ID",
                table: "TB_TODO",
                column: "USER_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_TODO_TB_USER_USER_ID",
                table: "TB_TODO",
                column: "USER_ID",
                principalTable: "TB_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_TODO_TB_USER_USER_ID",
                table: "TB_TODO");

            migrationBuilder.DropIndex(
                name: "IX_TB_TODO_USER_ID",
                table: "TB_TODO");

            migrationBuilder.DropColumn(
                name: "USER_ID",
                table: "TB_TODO");

            migrationBuilder.AddColumn<string>(
                name: "USER",
                table: "TB_TODO",
                type: "varchar(120)",
                maxLength: 120,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_TODO_USER",
                table: "TB_TODO",
                column: "USER");
        }
    }
}
