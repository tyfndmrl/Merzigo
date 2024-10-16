﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Merzigo.ContentService.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ContentISoftDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Contents",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Contents");
        }
    }
}
