using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitConnect.Repositorio.Migrations
{
    public partial class InclusaoCampoAtivoTreinoEExercicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Treinos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Exercicios",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Treinos");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Exercicios");
        }
    }
}
