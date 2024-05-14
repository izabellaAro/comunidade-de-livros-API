using ComunidadeLivros.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComunidadeLivros.DataAccess.Persistence.Configurations;

public class LivroConfiguration : IEntityTypeConfiguration<Livro>
{
    public void Configure(EntityTypeBuilder<Livro> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Titulo)
            .HasMaxLength(90)
            .IsRequired();

        builder.Property(x => x.QntPag)
            .IsRequired();

        builder.HasOne(x => x.Autor)
            .WithMany()
            .HasForeignKey(x => x.AutorId);

        builder.HasOne(x => x.Genero)
            .WithMany()
            .HasForeignKey(x => x.GeneroId);

        builder.HasMany(x => x.Resenhas)
            .WithOne(x => x.Livro)
            .HasForeignKey(x => x.LivroId);

        builder.Property(x => x.ChaveImg)
            .HasMaxLength(120)
            .IsRequired(false);
    }
}
