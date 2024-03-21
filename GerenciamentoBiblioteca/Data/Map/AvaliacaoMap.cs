using GerenciamentoBiblioteca.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoBiblioteca.Data.Map
{
    public class AvaliacaoMap : IEntityTypeConfiguration<AvaliacaoModel>
    {
        public void Configure(EntityTypeBuilder<AvaliacaoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Pontuacao).IsRequired();
            builder.Property(x => x.Comentario).IsRequired().HasMaxLength(255);
            builder.Property(x => x.DataAvaliacao).IsRequired();
            builder.Property(x => x.LivroId);
            builder.HasOne(x => x.Livro);
            builder.Property(x => x.UsuarioId);
            builder.HasOne(X => X.Usuario);
        }
    }
}
