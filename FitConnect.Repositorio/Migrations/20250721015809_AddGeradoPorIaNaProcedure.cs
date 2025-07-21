using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitConnect.Repositorio.Migrations
{
    public partial class AddGeradoPorIaNaProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE OR ALTER PROCEDURE TreinosPorGrupoMuscular
                    @GrupoMuscular INT
                AS
                BEGIN
                    SET NOCOUNT ON;

                    SELECT 
                        t.Id,
                        t.Nome,
                        t.PersonalId,
                        t.Ativo,
                        t.GeradoPorIa,                                          
                        p.Nome       AS PersonalNome,
                        quantidadeExercicios.quantidadeExercicios,
                        quantidadeExercicios.quantidadeExercicios * 5 AS TempoEstimado
                    FROM Treinos t
                    INNER JOIN Usuarios p 
                        ON p.Id = t.PersonalId
                    INNER JOIN ExerciciosTreinos et 
                        ON et.TreinoId = t.Id
                    INNER JOIN Exercicios e 
                        ON e.Id = et.ExercicioId
                    LEFT JOIN (
                        SELECT 
                            TreinoId, 
                            COUNT(*) AS quantidadeExercicios
                        FROM ExerciciosTreinos et2
                        INNER JOIN Exercicios e2 
                            ON e2.Id = et2.ExercicioId
                        WHERE e2.Ativo = 1
                        GROUP BY TreinoId
                    ) quantidadeExercicios 
                        ON quantidadeExercicios.TreinoId = t.Id
                    WHERE e.GrupoMuscular = @GrupoMuscular 
                    AND t.Ativo        = 1 
                    AND e.Ativo        = 1
                    GROUP BY 
                        t.Id, 
                        t.Nome, 
                        t.PersonalId, 
                        t.Ativo,
                        t.GeradoPorIa,
                        p.Nome, 
                        quantidadeExercicios.quantidadeExercicios;
                END
    ");
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS TreinosPorGrupoMuscular;");
        }
    }
}
