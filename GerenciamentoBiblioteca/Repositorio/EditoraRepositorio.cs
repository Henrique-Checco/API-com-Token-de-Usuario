using GerenciamentoBiblioteca.Data;
using GerenciamentoBiblioteca.Models;
using GerenciamentoBiblioteca.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoBiblioteca.Repositorio
{
    public class EditoraRepositorio : IEditoraRepositorio
    {
        private readonly GerenciamentoBibliotecaDbContext _dbContext;

        public EditoraRepositorio(GerenciamentoBibliotecaDbContext gerenciamentoBibliotecaDbContext)
        {
            _dbContext = gerenciamentoBibliotecaDbContext;
        }

        public async Task<EditoraModel> BuscarPorId(int id)
        {
            return await _dbContext.Editoras.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<EditoraModel>> BuscarTodasEditoras()
        {
            return await _dbContext.Editoras.ToListAsync();
        }
        public async Task<EditoraModel> Adicionar(EditoraModel editora)
        {
            await _dbContext.Editoras.AddAsync(editora);
            await _dbContext.SaveChangesAsync();
            return editora;
        }

        public async Task<bool> Apagar(int id)
        {
            EditoraModel editoraPorId = await BuscarPorId(id);
            if (editoraPorId == null)
            {
                throw new Exception($"Editora do ID: {id} não encontrada");
            }

            _dbContext.Editoras.Remove(editoraPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<EditoraModel> Atualizar(EditoraModel editora, int id)
        {
            EditoraModel editoraPorId = await BuscarPorId(id);
            if (editoraPorId == null)
            {
                throw new Exception($"Editora do ID: {id} não encontrada");
            }

            editoraPorId.Nome = editora.Nome;
            editoraPorId.Localizacao = editora.Localizacao;
            editoraPorId.AnoFundacao = editora.AnoFundacao;
            editoraPorId.LivroId = editora.LivroId;

            _dbContext.Editoras.Update(editoraPorId);
            await _dbContext.SaveChangesAsync();

            return editora;
        }
    }
}
