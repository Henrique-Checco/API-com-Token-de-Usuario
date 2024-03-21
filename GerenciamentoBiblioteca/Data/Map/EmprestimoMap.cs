using GerenciamentoBiblioteca.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoBiblioteca.Data.Map
{
    public class EmprestimoMap : IEntityTypeConfiguration<EmprestimoModel>
    {
        public void Configure(EntityTypeBuilder<EmprestimoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DataEmprestimo).IsRequired();
            builder.Property(x => x.DataDevolucao).IsRequired();
            builder.Property(x => x.StatusEmprestimo).IsRequired();
            builder.Property(x => x.LivroId);
            builder.HasOne(x => x.Livro);
            builder.Property(x => x.UsuarioId);
            builder.HasOne(X => X.Usuario);
        }
    }
}
