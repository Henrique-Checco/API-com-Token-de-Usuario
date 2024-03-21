using GerenciamentoBiblioteca.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoBiblioteca.Data.Map
{
    public class LivroMap : IEntityTypeConfiguration<LivroModel>
    {
        public void Configure(EntityTypeBuilder<LivroModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Titulo).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Genero).IsRequired().HasMaxLength(255);
            builder.Property(x => x.AnoPublicacao).IsRequired();
            builder.Property(x => x.ISBN).IsRequired();
            builder.Property(x => x.Sinopse).IsRequired().HasMaxLength(255);
        }
    }
}
