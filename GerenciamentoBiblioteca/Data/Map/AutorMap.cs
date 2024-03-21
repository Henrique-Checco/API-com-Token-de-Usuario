using GerenciamentoBiblioteca.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoBiblioteca.Data.Map
{
        public class AutorMap : IEntityTypeConfiguration<AutorModel>
        {
            public void Configure(EntityTypeBuilder<AutorModel> builder)
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
                builder.Property(x => x.Nacionalidade).IsRequired().HasMaxLength(255);
                builder.Property(x => x.DataNascimento).IsRequired();
            }
        }
}
