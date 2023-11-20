using ComunidadeLivros.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComunidadeLivros.DataAccess.Persistence.Configurations;

public class ResenhaConfiguration : IEntityTypeConfiguration<Resenha>
{
    public void Configure(EntityTypeBuilder<Resenha> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.TextoResenha).HasMaxLength(3000).IsRequired();
    }
}
