using FitConnect.Dominio.Entidades;
using FitConnect.Repositorio.Configuracoes;
using Microsoft.EntityFrameworkCore;

namespace FitConnect.Repositorio.Contexto
{
    public class FitConnectContexto : DbContext
    {
        public FitConnectContexto(DbContextOptions<FitConnectContexto> options) : base(options)
        {
            
        }

        public FitConnectContexto()
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Treino> Treinos { get; set; }
        public DbSet<Exercicio> Exercicios { get; set; }
        public DbSet<TreinoCompartilhado> TreinosCompartilhados { get; set;}
        public DbSet<ExercicioTreino> ExerciciosTreinos { get; set; }

        

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Server=NOTE-AFS\\SQLEXPRESS;Database=Fitconnect;TrustServerCertificate=True;Trusted_Connection=True;";
                optionsBuilder.UseSqlServer(connectionString);
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