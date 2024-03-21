using GerenciamentoBiblioteca.Data;
using GerenciamentoBiblioteca.Models;
using GerenciamentoBiblioteca.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoBiblioteca.Repositorio
{
    public class ReservaRepositorio : IReservaRepositorio
    {
        private readonly GerenciamentoBibliotecaDbContext _dbContext;

        public ReservaRepositorio(GerenciamentoBibliotecaDbContext gerenciamentoBibliotecaDbContext)
        {
            _dbContext = gerenciamentoBibliotecaDbContext;
        }

        public async Task<ReservaModel> BuscarPorId(int id)
        {
            return await _dbContext.Reservas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ReservaModel>> BuscarTodasReservas()
        {
            return await _dbContext.Reservas.ToListAsync();
        }
        public async Task<ReservaModel> Adicionar(ReservaModel reserva)
        {
            await _dbContext.Reservas.AddAsync(reserva);
            await _dbContext.SaveChangesAsync();
            return reserva;
        }

        public async Task<bool> Apagar(int id)
        {
            ReservaModel reservaPorId = await BuscarPorId(id);
            if (reservaPorId == null)
            {
                throw new Exception($"Reserva do ID: {id} não encontrada");
            }

            _dbContext.Reservas.Remove(reservaPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ReservaModel> Atualizar(ReservaModel reserva, int id)
        {
            ReservaModel reservaPorId = await BuscarPorId(id);
            if (reservaPorId == null)
            {
                throw new Exception($"Reserva do ID: {id} não encontrada");
            }

            reservaPorId.DataReserva = reserva.DataReserva;
            reservaPorId.StatusReserva = reserva.StatusReserva;
            reservaPorId.LivroId = reserva.LivroId;
            reservaPorId.UsuarioId = reserva.UsuarioId;

            _dbContext.Reservas.Update(reservaPorId);
            await _dbContext.SaveChangesAsync();

            return reserva;
        }
    }
}
