using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movizi_Portal.Migrations
{
    /// <inheritdoc />
    public partial class convertDurationIntoInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Projects");

            migrationBuilder.AddColumn<int>(
                name: "ProjectDuration",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectDuration",
                table: "Projects");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Projects",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
