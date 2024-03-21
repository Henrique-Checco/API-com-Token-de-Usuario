using GerenciamentoBiblioteca.Data;
using GerenciamentoBiblioteca.Models;
using GerenciamentoBiblioteca.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoBiblioteca.Repositorio
{
    public class AvaliacaoRepositorio : IAvaliacaoRepositorio
    {
        private readonly GerenciamentoBibliotecaDbContext _dbContext;

        public AvaliacaoRepositorio(GerenciamentoBibliotecaDbContext gerenciamentoBibliotecaDbContext)
        {
            _dbContext = gerenciamentoBibliotecaDbContext;
        }

        public async Task<AvaliacaoModel> BuscarPorId(int id)
        {
            return await _dbContext.Avaliacoes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<AvaliacaoModel>> BuscarTodasAvaliacoes()
        {
            return await _dbContext.Avaliacoes.ToListAsync();
        }
        public async Task<AvaliacaoModel> Adicionar(AvaliacaoModel avaliacao)
        {
            await _dbContext.Avaliacoes.AddAsync(avaliacao);
            await _dbContext.SaveChangesAsync();
            return avaliacao;
        }

        public async Task<bool> Apagar(int id)
        {
            AvaliacaoModel avaliacaoPorId = await BuscarPorId(id);
            if (avaliacaoPorId == null)
            {
                throw new Exception($"Avaliação do ID: {id} não encontrada");
            }

            _dbContext.Avaliacoes.Remove(avaliacaoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<AvaliacaoModel> Atualizar(AvaliacaoModel avaliacao, int id)
        {
            AvaliacaoModel avaliacaoPorId = await BuscarPorId(id);
            if (avaliacaoPorId == null)
            {
                throw new Exception($"Avaliacao do ID: {id} não encontrada");
            }

            avaliacaoPorId.Pontuacao = avaliacao.Pontuacao;
            avaliacaoPorId.Comentario = avaliacao.Comentario;
            avaliacaoPorId.DataAvaliacao = avaliacao.DataAvaliacao;
            avaliacaoPorId.LivroId = avaliacao.LivroId;
            avaliacaoPorId.UsuarioId = avaliacao.UsuarioId;

            _dbContext.Avaliacoes.Update(avaliacaoPorId);
            await _dbContext.SaveChangesAsync();

            return avaliacao;
        }
    }
}
