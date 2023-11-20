using ComunidadeLivros.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComunidadeLivros.DataAccess.Persistence.Configurations;

public class GeneroConfiguration : IEntityTypeConfiguration<Genero>
{
    public void Configure(EntityTypeBuilder<Genero> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nome).HasMaxLength(60).IsRequired();
    }
}
