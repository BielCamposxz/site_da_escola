using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace site_da_escola.Migrations
{
    /// <inheritdoc />
    public partial class nome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Feedbacks",
                newName: "Nome");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Feedbacks",
                newName: "Name");
        }
    }
}
