using System.Formats.Asn1;
using Dapper;
using FitConnect.Dominio.Entidades;
using FitConnect.Repositorio.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitConnect.Repositorio.DataAccess
{
    public class TreinoRepositorio : BaseRepositorio, ITreinoRepositorio
    {
        public TreinoRepositorio(FitConnectContexto contexto) : base(contexto)
        {
            
        }
        public async Task AtualizarAsync(Treino treino)
        {
            _contexto.Treinos.Update(treino);
            await _contexto.SaveChangesAsync();
        }

        public async Task DeletarAsync(Treino treino)
        {
            _contexto.Treinos.Remove(treino);
            await _contexto.SaveChangesAsync();
        }

        public async Task<IEnumerable<Treino>> ListarAsync(bool ativo)
        {
            return await _contexto.Treinos.Where(t => t.Ativo == ativo).ToListAsync();
        }

        public async Task<IEnumerable<Treino>> ListarTreinosPersonal(int personalId)
        {
            return await _contexto.Treinos.Where(t => t.PersonalId == personalId)
                                            .Include(t => t.ExerciciosTreino)
                                            .Where(t => t.Ativo == true)
                                            .ToListAsync();
        }

        public async Task<IEnumerable<TreinoStoredProcedure>> ListarPorGrupoMuscularAsync(int grupoMuscular)
        {
            using var connection = _contexto.Database.GetDbConnection();
            const string sql = @"EXEC TreinosPorGrupoMuscular @GrupoMuscular";

            if (connection.State == System.Data.ConnectionState.Closed)
                await connection.OpenAsync();

            var parametros = new { GrupoMuscular = grupoMuscular };
            var resultado = await connection.QueryAsync<TreinoStoredProcedure>(sql, parametros);
            return resultado;
        }

        public async Task<Treino> ObterPorIdAsync(int treinoId)
        {
            return await _contexto.Treinos
                            .Include(t => t.ExerciciosTreino)
                            .Where(t => t.Id == treinoId)
                            .FirstOrDefaultAsync();
        }

        public async Task<int> SalvarAsync(Treino treino)
        {
            await _contexto.Treinos.AddAsync(treino);
            await _contexto.SaveChangesAsync();

            return treino.Id;
        }
    }
}