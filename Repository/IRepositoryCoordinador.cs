﻿using ProyectoBE.Controllers;
using ProyectoBE.Models;

namespace ProyectoBE.Repository
{
    public interface IRepositoryCoordinador
    {
        Task<int> crear(Coordinador coordinador);
        Task<Coordinador> ConsultarPorId(int id);
        Task<List<Coordinador>> ConsultarTodos();
        Task Update(Coordinador coordinador);
        Task<int> Delete(int id);
        Task crear(Controllers.CoordinadorDeRevisionController coordinador);
        Task Update(CoordinadorDeRevisionController coordinador);
    }
}
