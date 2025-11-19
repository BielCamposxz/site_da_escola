using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace site_da_escola.Migrations
{
    /// <inheritdoc />
    public partial class id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_Estrangeiro",
                table: "FixadosTemprariamente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_Estrangeiro",
                table: "Fixados",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id_Estrangeiro",
                table: "FixadosTemprariamente");

            migrationBuilder.DropColumn(
                name: "Id_Estrangeiro",
                table: "Fixados");
        }
    }
}
