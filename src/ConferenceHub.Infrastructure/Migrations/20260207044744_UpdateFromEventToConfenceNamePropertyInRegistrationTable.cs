using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConferenceHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFromEventToConfenceNamePropertyInRegistrationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EventPublicId",
                table: "Registration",
                newName: "ConferencePublicId");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Registration",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Registration");

            migrationBuilder.RenameColumn(
                name: "ConferencePublicId",
                table: "Registration",
                newName: "EventPublicId");
        }
    }
}
