using GerenciamentoBiblioteca.Data;
using GerenciamentoBiblioteca.Models;
using GerenciamentoBiblioteca.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoBiblioteca.Repositorio
{
    public class EmprestimoRepositorio : IEmprestimoRepositorio
    {
        private readonly GerenciamentoBibliotecaDbContext _dbContext;

        public EmprestimoRepositorio(GerenciamentoBibliotecaDbContext gerenciamentoBibliotecaDbContext)
        {
            _dbContext = gerenciamentoBibliotecaDbContext;
        }

        public async Task<EmprestimoModel> BuscarPorId(int id)
        {
            return await _dbContext.Emprestimos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<EmprestimoModel>> BuscarTodosEmprestimos()
        {
            return await _dbContext.Emprestimos.ToListAsync();
        }
        public async Task<EmprestimoModel> Adicionar(EmprestimoModel emprestimo)
        {
            await _dbContext.Emprestimos.AddAsync(emprestimo);
            await _dbContext.SaveChangesAsync();
            return emprestimo;
        }

        public async Task<bool> Apagar(int id)
        {
            EmprestimoModel emprestimoPorId = await BuscarPorId(id);
            if (emprestimoPorId == null)
            {
                throw new Exception($"Empréstimo do ID: {id} não encontrado");
            }

            _dbContext.Emprestimos.Remove(emprestimoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<EmprestimoModel> Atualizar(EmprestimoModel emprestimo, int id)
        {
            EmprestimoModel emprestimoPorId = await BuscarPorId(id);
            if (emprestimoPorId == null)
            {
                throw new Exception($"Empréstimo do ID: {id} não encontrado");
            }

            emprestimoPorId.DataEmprestimo = emprestimo.DataEmprestimo;
            emprestimoPorId.DataDevolucao = emprestimo.DataDevolucao;
            emprestimoPorId.StatusEmprestimo = emprestimo.StatusEmprestimo;
            emprestimoPorId.LivroId = emprestimo.LivroId;
            emprestimoPorId.UsuarioId = emprestimo.UsuarioId;

            _dbContext.Emprestimos.Update(emprestimoPorId);
            await _dbContext.SaveChangesAsync();

            return emprestimo;
        }
    }
}
