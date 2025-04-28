using FitConnect.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitConnect.Repositorio.Configuracoes
{
    public class TreinoConfiguracoes : IEntityTypeConfiguration<Treino>
    {
        public void Configure(EntityTypeBuilder<Treino> builder)
        {
            builder.ToTable("Treinos").HasKey(t => t.Id);

            builder.Property(nameof(Treino.Id)).HasColumnName("Id");
            builder.Property(nameof(Treino.Nome)).HasColumnName("Nome").IsRequired(true);
            builder.Property(nameof(Treino.PersonalId)).HasColumnName("PersonalId").IsRequired(true);

            builder
                .HasOne(t => t.Personal)
                .WithMany(u => u.Treinos)
                .HasForeignKey(t => t.PersonalId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}