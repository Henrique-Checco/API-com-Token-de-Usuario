using GerenciamentoBiblioteca.Models;

namespace GerenciamentoBiblioteca.Repositorio.Interface
{
    public interface IAvaliacaoRepositorio
    {
        Task<List<AvaliacaoModel>> BuscarTodasAvaliacoes();
        Task<AvaliacaoModel> BuscarPorId(int id);
        Task<AvaliacaoModel> Adicionar(AvaliacaoModel avalicao);
        Task<AvaliacaoModel> Atualizar(AvaliacaoModel avaliacao, int id);
        Task<bool> Apagar(int id);
    }
}
