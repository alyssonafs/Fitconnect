using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitConnect.Repositorio.Migrations
{
    public partial class CriarStoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder.IsSqlServer())
            {
                migrationBuilder.Sql(
                @"
                CREATE PROCEDURE TreinosPorGrupoMuscular
                    @GrupoMuscular INT
                AS
                BEGIN
                    SET NOCOUNT ON;

                    SELECT 
                        t.Id,
                        t.Nome,
                        t.PersonalId,
                        t.Ativo,
                        p.Nome AS PersonalNome,
                        quantidadeExercicios.quantidadeExercicios,
                        quantidadeExercicios.quantidadeExercicios * 5 AS TempoEstimado
                    FROM Treinos t
                    INNER JOIN Usuarios p ON p.Id = t.PersonalId
                    INNER JOIN ExerciciosTreinos et ON et.TreinoId = t.Id
                    INNER JOIN Exercicios e ON e.Id = et.ExercicioId
                    
                    LEFT JOIN (
                        SELECT TreinoId, COUNT(*) AS quantidadeExercicios
                        FROM ExerciciosTreinos et
                        INNER JOIN Exercicios e ON e.Id = et.ExercicioId
                        WHERE e.Ativo = 1
                        GROUP BY TreinoId
                    ) quantidadeExercicios ON quantidadeExercicios.TreinoId = t.Id
                    WHERE e.GrupoMuscular = @GrupoMuscular 
                    AND t.Ativo = 1 
                    AND e.Ativo = 1
                    GROUP BY 
                        t.Id, t.Nome, t.PersonalId, t.Ativo, p.Nome, quantidadeExercicios.quantidadeExercicios
                END
                "
            );
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
