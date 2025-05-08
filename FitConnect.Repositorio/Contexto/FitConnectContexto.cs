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
        _options = options;
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (_options == null)
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