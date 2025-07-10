using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitConnect.Repositorio.Migrations
{
    public partial class SeedExerciciosIniciais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Exercicios",
                columns: new[] { "Id", "Ativo", "Descricao", "GrupoMuscular", "Nome", "VideoURL" },
                values: new object[,]
                {
                    { 1, true, "Exercício clássico para trabalhar a parte central do peitoral.", 0, "Supino Reto com Barra", "https://www.youtube.com/embed/rT7DgCr-3pg" },
                    { 2, true, "Foco no peitoral superior com maior amplitude.", 0, "Supino Inclinado com Halteres", "https://www.youtube.com/embed/8iPEnn-ltC8" },
                    { 3, true, "Exercício de isolamento para o peitoral.", 0, "Crossover no Cabo", "https://www.youtube.com/embed/taI4XduLpTk" },
                    { 4, true, "Trabalha o latíssimo do dorso.", 1, "Puxada Frente na Polia Alta", "https://www.youtube.com/embed/CAwf7n6Luuc" },
                    { 5, true, "Foco na parte média das costas.", 1, "Remada Curvada com Barra", "https://www.youtube.com/embed/vT2GjY_Umpw" },
                    { 6, true, "Trabalha espessura do dorso.", 1, "Remada Baixa com Triângulo", "https://www.youtube.com/embed/roCP6wCXPqo" },
                    { 7, true, "Exercício básico para bíceps.", 2, "Rosca Direta com Barra", "https://www.youtube.com/embed/kwG2ipFRgfo" },
                    { 8, true, "Movimento unilateral para foco e controle.", 2, "Rosca Alternada com Halteres", "https://www.youtube.com/embed/av7-8igSXTs" },
                    { 9, true, "Trabalha braquiorradial e antebraço.", 2, "Rosca Martelo", "https://www.youtube.com/embed/zC3nLlEvin4" },
                    { 10, true, "Isolamento do tríceps com polia.", 3, "Tríceps Pulley", "https://www.youtube.com/embed/I80Xx7pA8jQ" },
                    { 11, true, "Trabalha todas as cabeças do tríceps.", 3, "Tríceps Testa com Barra", "https://www.youtube.com/embed/d_KZxkY_0cM" },
                    { 12, true, "Tríceps com peso corporal.", 3, "Mergulho entre Bancos", "https://www.youtube.com/embed/6kALZikXxLc" },
                    { 13, true, "Foco no deltoide anterior e lateral.", 4, "Desenvolvimento com Halteres", "https://www.youtube.com/embed/qEwKCR5JCog" },
                    { 14, true, "Isolamento para deltoide lateral.", 4, "Elevação Lateral", "https://www.youtube.com/embed/3VcKaXpzqRo" },
                    { 15, true, "Foco no deltoide anterior.", 4, "Elevação Frontal com Halteres", "https://www.youtube.com/embed/-t7fuZ0KhDA" },
                    { 16, true, "Exercício composto para pernas e glúteos.", 5, "Agachamento Livre", "https://www.youtube.com/embed/UXJrBgI2RxA" },
                    { 17, true, "Trabalha quadríceps, glúteos e posterior.", 5, "Leg Press 45°", "https://www.youtube.com/embed/IZxyjW7MPJQ" },
                    { 18, true, "Isolamento para quadríceps.", 5, "Cadeira Extensora", "https://www.youtube.com/embed/YyvSfVjQeL0" },
                    { 19, true, "Movimento básico para abdominal superior.", 6, "Abdominal Supra no Solo", "https://www.youtube.com/embed/5ER5Of4MOPI" },
                    { 20, true, "Exercício isométrico para core.", 6, "Prancha Abdominal", "https://www.youtube.com/embed/pSHjTRCQxIw" },
                    { 21, true, "Trabalha principalmente o abdômen inferior.", 6, "Elevação de Pernas na Barra Fixa", "https://www.youtube.com/embed/l4kQd9eWclE" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercicios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exercicios",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Exercicios",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Exercicios",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Exercicios",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Exercicios",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Exercicios",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Exercicios",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Exercicios",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Exercicios",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Exercicios",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Exercicios",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Exercicios",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Exercicios",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Exercicios",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Exercicios",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Exercicios",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Exercicios",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Exercicios",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Exercicios",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Exercicios",
                keyColumn: "Id",
                keyValue: 21);
        }
    }
}
