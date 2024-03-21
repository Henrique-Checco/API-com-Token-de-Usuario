using GerenciamentoBiblioteca.Data;
using GerenciamentoBiblioteca.Models;
using GerenciamentoBiblioteca.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoBiblioteca.Repositorio
{
    public class AutorRepositorio : IAutorRepositorio
    {
        private readonly GerenciamentoBibliotecaDbContext _dbContext;

        public AutorRepositorio(GerenciamentoBibliotecaDbContext gerenciamentoBibliotecaDbContext)
        {
            _dbContext = gerenciamentoBibliotecaDbContext;
        }

        public async Task<AutorModel> BuscarPorId(int id)
        {
            return await _dbContext.Autores.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<AutorModel>> BuscarTodosAutores()
        {
            return await _dbContext.Autores.ToListAsync();
        }
        public async Task<AutorModel> Adicionar(AutorModel autor)
        {
            await _dbContext.Autores.AddAsync(autor);
            await _dbContext.SaveChangesAsync();
            return autor;
        }

        public async Task<bool> Apagar(int id)
        {
            AutorModel autorPorId = await BuscarPorId(id);
            if (autorPorId == null)
            {
                throw new Exception($"Autor do ID: {id} não encontrado");
            }

            _dbContext.Autores.Remove(autorPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<AutorModel> Atualizar(AutorModel autor, int id)
        {
            AutorModel autorPorId = await BuscarPorId(id);
            if (autorPorId == null)
            {
                throw new Exception($"Autor do ID: {id} não encontrado");
            }

            autorPorId.Nome = autor.Nome;
            autorPorId.Nacionalidade = autor.Nacionalidade;
            autorPorId.DataNascimento = autor.DataNascimento;

            _dbContext.Autores.Update(autorPorId);
            await _dbContext.SaveChangesAsync();

            return autor;
        }
    }
}
