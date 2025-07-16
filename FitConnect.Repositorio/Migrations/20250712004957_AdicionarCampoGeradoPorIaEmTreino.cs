using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitConnect.Repositorio.Migrations
{
    public partial class AdicionarCampoGeradoPorIaEmTreino : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "GeradoPorIa",
                table: "Treinos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GeradoPorIa",
                table: "Treinos");
        }
    }
}
