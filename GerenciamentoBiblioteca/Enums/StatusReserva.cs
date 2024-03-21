using System.ComponentModel;

namespace GerenciamentoBiblioteca.Enums
{
    public enum StatusReserva
    {
        [Description("Disponivel")]
        Disponivel = 1,
        [Description("Reservado")]
        Reservado = 2,
    }
}
