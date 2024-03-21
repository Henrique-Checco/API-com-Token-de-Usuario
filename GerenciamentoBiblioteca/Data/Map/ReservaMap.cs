using GerenciamentoBiblioteca.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoBiblioteca.Data.Map
{
    public class ReservaMap : IEntityTypeConfiguration<ReservaModel>
    {
        public void Configure(EntityTypeBuilder<ReservaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DataReserva).IsRequired();
            builder.Property(x => x.StatusReserva).IsRequired();
            builder.Property(x => x.LivroId);
            builder.HasOne(x => x.Livro);
            builder.Property(x => x.UsuarioId);
            builder.HasOne(X => X.Usuario);
        }
    }
}
