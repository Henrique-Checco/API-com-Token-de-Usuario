﻿using GerenciamentoBiblioteca.Models;

namespace GerenciamentoBiblioteca.Repositorio.Interface
{
    public interface IReservaRepositorio
    {
        Task<List<ReservaModel>> BuscarTodasReservas();
        Task<ReservaModel> BuscarPorId(int id);
        Task<ReservaModel> Adicionar(ReservaModel reserva);
        Task<ReservaModel> Atualizar(ReservaModel reserva, int id);
        Task<bool> Apagar(int id);
    }
}
