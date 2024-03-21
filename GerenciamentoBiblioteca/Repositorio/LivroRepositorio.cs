using GerenciamentoBiblioteca.Data;
using GerenciamentoBiblioteca.Models;
using GerenciamentoBiblioteca.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoBiblioteca.Repositorio
{
    public class LivroRepositorio : ILivroRepositorio
    {
        private readonly GerenciamentoBibliotecaDbContext _dbContext;

        public LivroRepositorio(GerenciamentoBibliotecaDbContext gerenciamentoBibliotecaDbContext)
        {
            _dbContext = gerenciamentoBibliotecaDbContext;
        }

        public async Task<LivroModel> BuscarPorId(int id)
        {
            return await _dbContext.Livros.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<LivroModel>> BuscarTodosLivros()
        {
            return await _dbContext.Livros.ToListAsync();
        }
        public async Task<LivroModel> Adicionar(LivroModel livro)
        {
            await _dbContext.Livros.AddAsync(livro);
            await _dbContext.SaveChangesAsync();
            return livro;
        }

        public async Task<bool> Apagar(int id)
        {
            LivroModel livroPorId = await BuscarPorId(id);
            if (livroPorId == null)
            {
                throw new Exception($"Livro do ID: {id} não encontrado");
            }

            _dbContext.Livros.Remove(livroPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<LivroModel> Atualizar(LivroModel livro, int id)
        {
            LivroModel livroPorId = await BuscarPorId(id);
            if (livroPorId == null)
            {
                throw new Exception($"Livro do ID: {id} não encontrado");
            }

            livroPorId.Titulo = livro.Titulo;
            livroPorId.Genero = livro.Genero;
            livroPorId.AnoPublicacao = livro.AnoPublicacao;
            livroPorId.ISBN = livro.ISBN;
            livroPorId.Sinopse = livro.Sinopse;

            _dbContext.Livros.Update(livroPorId);
            await _dbContext.SaveChangesAsync();

            return livro;
        }
    }
}
