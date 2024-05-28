using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoListApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedJobs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_jobs",
                table: "jobs");

            migrationBuilder.RenameTable(
                name: "jobs",
                newName: "JobList");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobList",
                table: "JobList",
                column: "Id");

            migrationBuilder.InsertData(
                table: "JobList",
                columns: new[] { "Id", "CreatedAt", "JobDescription", "JobTitle", "isCompleted" },
                values: new object[] { 10, new DateTime(2023, 5, 9, 12, 30, 0, 655, DateTimeKind.Local).AddTicks(7440), "For indecfugiat. Temporibus, voluptatibus.", "Charcuterie", false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JobList",
                table: "JobList");

            migrationBuilder.DeleteData(
                table: "JobList",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.RenameTable(
                name: "JobList",
                newName: "jobs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_jobs",
                table: "jobs",
                column: "Id");
        }
    }
}
