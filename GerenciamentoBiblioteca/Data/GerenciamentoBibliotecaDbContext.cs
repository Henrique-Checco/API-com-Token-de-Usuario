using GerenciamentoBiblioteca.Data.Map;
using GerenciamentoBiblioteca.Models;
using Microsoft.EntityFrameworkCore;
using static GerenciamentoBiblioteca.Data.GerenciamentoBibliotecaDbContext;

namespace GerenciamentoBiblioteca.Data
{
    public class GerenciamentoBibliotecaDbContext : DbContext
    {
        public GerenciamentoBibliotecaDbContext(DbContextOptions<GerenciamentoBibliotecaDbContext> options) : base(options)
        {
        }

        public DbSet<AutorModel> Autores { get; set; }
        public DbSet<AvaliacaoModel> Avaliacoes { get; set; }
        public DbSet<EditoraModel> Editoras { get; set; }
        public DbSet<EmprestimoModel> Emprestimos { get; set; }
        public DbSet<LivroModel> Livros { get; set; }
        public DbSet<ReservaModel> Reservas { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AutorMap());
            modelBuilder.ApplyConfiguration(new AvaliacaoMap());
            modelBuilder.ApplyConfiguration(new LivroMap());
            modelBuilder.ApplyConfiguration(new EditoraMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new EmprestimoMap());
            modelBuilder.ApplyConfiguration(new ReservaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
