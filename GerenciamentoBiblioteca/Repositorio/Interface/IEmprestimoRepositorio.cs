using GerenciamentoBiblioteca.Models;

namespace GerenciamentoBiblioteca.Repositorio.Interface
{
    public interface IEmprestimoRepositorio
    {
        Task<List<EmprestimoModel>> BuscarTodosEmprestimos();
        Task<EmprestimoModel> BuscarPorId(int id);
        Task<EmprestimoModel> Adicionar(EmprestimoModel emprestimo);
        Task<EmprestimoModel> Atualizar(EmprestimoModel emprestimo, int id);
        Task<bool> Apagar(int id);
    }
}
