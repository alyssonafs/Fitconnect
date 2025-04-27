using FitConnect.Dominio.Entidades;
using FitConnect.Repositorio.Configuracoes;
using Microsoft.EntityFrameworkCore;

namespace FitConnect.Repositorio.Contexto
{
    public class FitConnectContexto : DbContext
    {
        private readonly DbContextOptions _options;

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Treino> Treinos { get; set; }
        public DbSet<Exercicio> Exercicios { get; set; }
        public DbSet<TreinoCompartilhado> TreinosCompartilhados { get; set;}
        public DbSet<ExercicioTreino> ExerciciosTreinos { get; set; }

        public FitConnectContexto()
        {

        }

        public FitConnectContexto(DbContextOptions options) : base(options)
        {
            _options = options;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_options == null)
            {
                optionsBuilder.UseSqlite(@"Filename=./fitconnect.sqlite");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguracoes());
            modelBuilder.ApplyConfiguration(new TreinoConfiguracoes());
            modelBuilder.ApplyConfiguration(new ExercicioConfiguracoes());
            modelBuilder.ApplyConfiguration(new TreinoCompartilhadoConfiguracoes());
            modelBuilder.ApplyConfiguration(new ExercicioTreinoConfiguracoes());
        }
    }
}