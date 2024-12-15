using ProyectoBE.Models;

namespace ProyectoBE.Repository
{
    public interface IRepositoryPropuesta
    {
        Task<int> crear(Propuesta propuesta);
        Task<Propuesta> ConsultarPorId(int id);
        Task<List<Propuesta>> ConsultarTodos();
        Task Update(Propuesta propuesta);
        Task<int> Delete(int id);
    }
}
