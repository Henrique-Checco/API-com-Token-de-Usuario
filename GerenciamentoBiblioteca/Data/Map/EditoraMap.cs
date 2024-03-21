using GerenciamentoBiblioteca.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoBiblioteca.Data.Map
{
    public class EditoraMap : IEntityTypeConfiguration<EditoraModel>
    {
        public void Configure(EntityTypeBuilder<EditoraModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Localizacao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.AnoFundacao).IsRequired();
            builder.Property(x => x.LivroId);
            builder.HasOne(x => x.Livro);
        }
    }
}
