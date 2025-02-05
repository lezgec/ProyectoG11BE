using ProyectoBE.Controllers;
using ProyectoBE.Models;


namespace ProyectoBE.Repository
{
    public interface IRepositoryPropuesta
    {
        Task<int> Crear(Propuesta propuesta);
        Task<List<Propuesta>> ConsultarTodas();
        Task<Propuesta?> ConsultarPorId(int id);
        Task Update(Propuesta propuesta);
        Task<int> Delete(int id);
        Task Crear(RevisorDePropuestasController revisor);
    }
}

