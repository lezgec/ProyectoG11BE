using ProyectoBE.Controllers;
using ProyectoBE.Models;

namespace ProyectoBE.Repository
{
    public interface IRepositoryGestor
    {
        Task<int> Crear(Gestor gestor);
        Task<Gestor?> ConsultarPorId(int id);
        Task<Gestor?> ConsultarPorCedula(string cedula);
        Task<List<Gestor>> ConsultarTodos();
        Task<List<int>> ConsultarPropuestasPorGestor(int gestorId);
        Task Update(Gestor gestor);
        Task<int> Delete(int id);
    }
}

