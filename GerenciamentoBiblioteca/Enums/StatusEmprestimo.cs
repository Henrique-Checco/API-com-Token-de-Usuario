using System.ComponentModel;

namespace GerenciamentoBiblioteca.Enums
{
    public enum StatusEmprestimo
    {
        [Description("Disponivel")]
        Disponivel = 1,
        [Description("AguardandoRetirada")]
        AguardandoRetirada = 2,
        [Description("Emprestado")]
        Emprestado = 3,
    }
}
