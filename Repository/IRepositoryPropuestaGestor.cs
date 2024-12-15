using ProyectoBE.Models;

namespace ProyectoBE.Repository
{
    public interface IRepositoryPropuestaGestor
    {
        Task<int> crear(PropuestaGestor propuestaGestor);
        Task<PropuestaGestor> ConsultarPorId(int id);
        Task<List<PropuestaGestor>> ConsultarTodos();
        Task Update(PropuestaGestor propuestaGestor);
        Task<int> Delete(int id);
    }
}
