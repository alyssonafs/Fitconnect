using FitConnect.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitConnect.Repositorio.Configuracoes
{
    public class TreinoCompartilhadoConfiguracoes : IEntityTypeConfiguration<TreinoCompartilhado>
    {
        public void Configure(EntityTypeBuilder<TreinoCompartilhado> builder)
        {
            builder.ToTable("TreinosCompartilhados").HasKey(t => t.Id);

            builder.Property(nameof(TreinoCompartilhado.Id)).HasColumnName("Id");
            builder.Property(nameof(TreinoCompartilhado.TreinoId)).HasColumnName("TreinoId").IsRequired(true);
            builder.Property(nameof(TreinoCompartilhado.AlunoId)).HasColumnName("AlunoId").IsRequired(true);
            builder.Property(nameof(TreinoCompartilhado.DataCompartilhamento)).HasColumnName("DataCompartilhamento").IsRequired(true);

            builder
                .HasOne(tc => tc.Treino)
                .WithMany(t => t.TreinosCompartilhados)
                .HasForeignKey(tc => tc.TreinoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(tc => tc.Usuario)
                .WithMany(u => u.TreinosCompartilhados)
                .HasForeignKey(tc => tc.AlunoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}