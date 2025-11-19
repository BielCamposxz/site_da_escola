using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace site_da_escola.Migrations
{
    /// <inheritdoc />
    public partial class descricao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "descricao",
                table: "Feedbacks",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "descricao",
                table: "Feedbacks");
        }
    }
}
