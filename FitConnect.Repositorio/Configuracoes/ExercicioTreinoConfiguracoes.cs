using FitConnect.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitConnect.Repositorio.Configuracoes
{
    public class ExercicioTreinoConfiguracoes : IEntityTypeConfiguration<ExercicioTreino>
    {
        public void Configure(EntityTypeBuilder<ExercicioTreino> builder)
        {
            builder.ToTable("ExerciciosTreinos").HasKey(e => e.Id);

            builder.Property(nameof(ExercicioTreino.Id)).HasColumnName("Id");
            builder.Property(nameof(ExercicioTreino.Serie)).HasColumnName("Serie");
            builder.Property(nameof(ExercicioTreino.TreinoId)).HasColumnName("TreinoId");
            builder.Property(nameof(ExercicioTreino.ExercicioId)).HasColumnName("ExercicioId");
        }
    }
}