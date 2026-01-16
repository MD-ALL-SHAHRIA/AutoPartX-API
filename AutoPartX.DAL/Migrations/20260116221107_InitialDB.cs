using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoPartX.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastRestocked",
                table: "Parts");

            migrationBuilder.RenameColumn(
                name: "OEMNumber",
                table: "Parts",
                newName: "OemNumber");

            migrationBuilder.RenameColumn(
                name: "PartName",
                table: "Parts",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OemNumber",
                table: "Parts",
                newName: "OEMNumber");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Parts",
                newName: "PartName");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastRestocked",
                table: "Parts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
