using ProyectoBE.Models;

namespace ProyectoBE.Repository
{
    public interface IRepositoryGestor
    {
        Task<int> crear(Gestor gestor);
        Task<Gestor> ConsultarPorId(int id);
        Task<List<Gestor>> ConsultarTodos();
        Task Update(Gestor gestor);
        Task<int> Delete(int id);
    }
}
