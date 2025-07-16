using FitConnect.Dominio.Entidades;
using FitConnect.Repositorio.Configuracoes;
using Microsoft.EntityFrameworkCore;


public class FitConnectContexto : DbContext
{
    private readonly DbContextOptions _options;

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Treino> Treinos { get; set; }
    public DbSet<Exercicio> Exercicios { get; set; }
    public DbSet<TreinoCompartilhado> TreinosCompartilhados { get; set; }
    public DbSet<ExercicioTreino> ExerciciosTreinos { get; set; }

    public FitConnectContexto()
    {
        
    }

    public FitConnectContexto(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (_options == null)
        {
            optionsBuilder.UseSqlServer("Server=NOTE264\\SQLEXPRESS;Database=Fitconnect;TrustServerCertificate=True;Trusted_Connection=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioConfiguracoes());
        modelBuilder.ApplyConfiguration(new TreinoConfiguracoes());
        modelBuilder.ApplyConfiguration(new ExercicioConfiguracoes());
        modelBuilder.ApplyConfiguration(new TreinoCompartilhadoConfiguracoes());
        modelBuilder.ApplyConfiguration(new ExercicioTreinoConfiguracoes());

        base.OnModelCreating(modelBuilder);
        ExercicioSeeder.Seed(modelBuilder);
    }

}