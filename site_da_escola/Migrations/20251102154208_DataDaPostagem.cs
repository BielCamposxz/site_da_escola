using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace site_da_escola.Migrations
{
    /// <inheritdoc />
    public partial class DataDaPostagem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataDePostagem",
                table: "Noticias",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDePostagem",
                table: "Eventos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataDePostagem",
                table: "Noticias");

            migrationBuilder.DropColumn(
                name: "DataDePostagem",
                table: "Eventos");
        }
    }
}
