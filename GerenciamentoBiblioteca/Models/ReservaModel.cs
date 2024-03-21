using GerenciamentoBiblioteca.Enums;

namespace GerenciamentoBiblioteca.Models
{
    public class ReservaModel
    {
        public int Id { get; set; }
        public DateOnly DataReserva { get; set; }
        public StatusReserva StatusReserva { get; set; }
        public int LivroId { get; set; }
        public LivroModel? Livro { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioModel? Usuario { get; set; }
    }
}
