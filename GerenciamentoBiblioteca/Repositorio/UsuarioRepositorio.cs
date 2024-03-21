using GerenciamentoBiblioteca.Data;
using GerenciamentoBiblioteca.Models;
using GerenciamentoBiblioteca.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoBiblioteca.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly GerenciamentoBibliotecaDbContext _dbContext;

        public UsuarioRepositorio(GerenciamentoBibliotecaDbContext gerenciamentoBibliotecaDbContext)
        {
            _dbContext = gerenciamentoBibliotecaDbContext;
        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário do ID: {id} não encontrado");
            }

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null)
            {
                throw new Exception($"Usuários do ID: {id} não encontrado");
            }

            usuarioPorId.Email = usuario.Email;
            usuarioPorId.Senha = usuario.Senha;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }
    }
}
