using FitConnect.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitConnect.Repositorio.Configuracoes
{
    public class ExercicioConfiguracoes : IEntityTypeConfiguration<Exercicio>
    {
        public void Configure(EntityTypeBuilder<Exercicio> builder)
        {
            builder.ToTable("Exercicios").HasKey(e => e.Id);

            builder.Property(nameof(Exercicio.Id)).HasColumnName("Id");
            builder.Property(nameof(Exercicio.Nome)).HasColumnName("Nome").IsRequired(true);
            builder.Property(nameof(Exercicio.GrupoMuscular)).HasColumnName("GrupoMuscular").IsRequired(true);
            builder.Property(nameof(Exercicio.Descricao)).HasColumnName("Descricao");
            builder.Property(nameof(Exercicio.VideoURL)).HasColumnName("VideoURL");
            builder.Property(nameof(Exercicio.Ativo)).HasColumnName("Ativo").IsRequired(true);
        }
    }
}